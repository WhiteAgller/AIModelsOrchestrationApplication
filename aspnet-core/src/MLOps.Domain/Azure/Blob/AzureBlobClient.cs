using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using MLOps.Azure.Client;
using MLOps.Config;
using MLOps.Consts;


namespace MLOps.Azure.Blob;

public class AzureBlobClient : IAzureBlobClient
{
    private readonly BlobServiceClient _client;
    private readonly IMLOpsClient _mlOpsClient;
    private readonly IConfigHandler _configHandler;

    public AzureBlobClient(IMLOpsClient mlOpsClient, IConfigHandler configHandler)
    {
        _mlOpsClient = mlOpsClient;
        _configHandler = configHandler;
        _client = new BlobServiceClient(GetStorageKeyAsync().GetAwaiter().GetResult());
    }
    
    private async Task<string> GetStorageKeyAsync()
    {
        return await _configHandler.GetConfigItem(Configuration.StorageKey);
    }    
    
    public async Task<string> GetTrainData(string pipelineId)
    {
        var componentsNames = await GetComponentNames(pipelineId);

        return await ReadDataFromBlob(componentsNames, "train_data/data.csv");
    }

    public async Task<string> GetTestData(string pipelineId)
    {
        var componentsNames = await GetComponentNames(pipelineId);

        return await ReadDataFromBlob(componentsNames, "test_data/data.csv");
    }

    public async Task<string> GetModel(string pipelineId)
    {
        var componentsNames = await GetComponentNames(pipelineId);
        
        return await ReadDataFromBlob(componentsNames, "model/trained_model/model.pkl");
    }
    
    private async Task<List<string>> GetComponentNames(string pipelineId)
    {
        var client = await _mlOpsClient.CreateAsync(_configHandler);
        var jobNoDetail = await client.GetJobNoDetail(pipelineId);
        var experimentId = await client.GetExperimentId(jobNoDetail.ExperimentName);
        var job = await client.GetJob(pipelineId, experimentId);

        return job.GraphNodesStatus.Select(component => component.Value.ReuseInfo != null
                ? component.Value.ReuseInfo.RunId
                : component.Value.RunId)
            .ToList();
    }

    private async Task<string> ReadDataFromBlob(List<string> componentsNames, string path)
    {
        foreach (var name in componentsNames)
        {
            var blobName = await _configHandler.GetConfigItem(Configuration.DataBlobContainerName);
            var dataFolderPath = await _configHandler.GetConfigItem(Configuration.DataFolderPath);
            
            var containerComponentClient = _client.GetBlobContainerClient(blobName);
            var blobClient =
                containerComponentClient.GetBlobClient($"{dataFolderPath}/{name}/{path}");
                
            if (!await blobClient.ExistsAsync())
            {
                continue;
            }

            var response = await blobClient.DownloadAsync();

            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                response.Value.Content.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }
            return Convert.ToBase64String(bytes);
        }
        return string.Empty;
    }
}