using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MLOps.Authentication;
using MLOps.Config;
using MLOps.Consts;
using MLOps.Entities;
using MLOps.Entities.Config;
using MLOps.Entities.Dataset;
using MLOps.Entities.Experiment;
using MLOps.Entities.Job;
using MLOps.Entities.Model;
using RestSharp;
using Volo.Abp.Domain.Repositories;

namespace MLOps.Azure.Client;

public class MlOpsClient : IDisposable, IMLOpsClient
{
    private readonly RestClient _pipelineClient;
    private readonly RestClient _restClient;
    private readonly RestClient _jobClient;
    private readonly IConfigHandler _configHandler;

    public MlOpsClient() { }
        
    private MlOpsClient(IConfigHandler configHandler, RestClient pipelineClient, RestClient restClient, RestClient jobClient)
    {
        _configHandler = configHandler;
        _pipelineClient = pipelineClient;
        _restClient = restClient;
        _jobClient = jobClient;
    }

    public async Task<MlOpsClient> CreateAsync(IConfigHandler configHandler)
    {
        var tenantId = await configHandler.GetConfigItem(Configuration.TenantId);
        var clientId = await configHandler.GetConfigItem(Configuration.ClientId);
        var clientSecret = await configHandler.GetConfigItem(Configuration.ClientSecret);
        var subscription = await configHandler.GetConfigItem(Configuration.Subscription);
        var resourceGroup = await configHandler.GetConfigItem(Configuration.ResourceGroup);
        var workspace = await configHandler.GetConfigItem(Configuration.Workspace);
        
        var auth = new MLOpsAuthenticator(
            $"https://login.microsoftonline.com/{tenantId}/oauth2/token",
            clientId,
            clientSecret);

        var pipelineClient = new RestClientOptions()
        {
            Authenticator = auth
        };

        var restClient = new RestClientOptions($"https://management.azure.com/subscriptions/{subscription}/resourceGroups/{resourceGroup}/providers/Microsoft.MachineLearningServices/workspaces/{workspace}/")
        {
            Authenticator = auth
        };

        var jobClient = new RestClientOptions($"https://ml.azure.com/api/westeurope/studioservice/apiv2/subscriptions/{subscription}/resourceGroups/{resourceGroup}/workspaces/{workspace}/")
        {
            Authenticator = auth
        };

        return new MlOpsClient(configHandler, new RestClient(pipelineClient), new RestClient(restClient), new RestClient(jobClient));
    }

    public async Task<PipelineResponseEntity> RunPipeline(string url, string inputBody)
    {
        var request = new RestRequest(url).AddBody(inputBody);
        return await _pipelineClient.PostAsync<PipelineResponseEntity>(request) ?? throw new InvalidOperationException();
    }
    
    public async Task<DatasetPutResponseEntity> CreateOrUpdateDataset(string name, string version, string inputBody)
    {
        var request = new RestRequest($"data/{name}/versions/{version}?api-version={AzureEnvironmentConsts.API_VERSION}").AddBody(inputBody);
        return await _restClient.PutAsync<DatasetPutResponseEntity>(request) ?? throw new InvalidOperationException();
    }

    public async Task<DatasetGetResponseEntity> GetDatasets()
    {
        var request = new RestRequest($"data?api-version={AzureEnvironmentConsts.API_VERSION}");
        return await _restClient.GetAsync<DatasetGetResponseEntity>(request) ?? throw new InvalidOperationException();
    }

    public async Task<DatasetGetVersionsResponseEntity> GetDatasetVersion(string name)
    {
        var request = new RestRequest($"data/{name}/versions?api-version={AzureEnvironmentConsts.API_VERSION}");
        return await _restClient.GetAsync<DatasetGetVersionsResponseEntity>(request) ?? throw new InvalidOperationException();
    }
    public async Task<ModelGetVersionsEntity> GetModelVersions(string modelName)
    {
        var request = new RestRequest($"models/{modelName}/versions?api-version={AzureEnvironmentConsts.API_VERSION}");
        return await _restClient.GetAsync<ModelGetVersionsEntity>(request) ?? throw new InvalidOperationException();
    }

    public async Task<List<ExperimentGetResponseEntity>> GetExperiments()
    {
        var request = new RestRequest("experiments");
        return await _jobClient.GetAsync<List<ExperimentGetResponseEntity>>(request) ?? throw new InvalidOperationException();
    }

    public async Task<string> GetExperimentId(string experimentName)
    {
        var request = new RestRequest("experiments");
        var experiments = await _jobClient.GetAsync<List<ExperimentGetResponseEntity>>(request);
        
        var experiment = experiments.Find(experiment => experiment.ExperimentName.Equals(experimentName));

        if (experiment == null)
        {
            throw new Exception("Experiment doesnt exist");
        }

        return experiment.ExperimentId;
    }

    public async Task<JobGetResponseNoDetailEntity> GetJobNoDetail(string pipelineId)
    {
        var request = new RestRequest($"pipelineruns/{pipelineId}");
        return await _jobClient.GetAsync<JobGetResponseNoDetailEntity>(request) ?? throw new InvalidOperationException();
    }

    public async Task<JobGetResponeEntity> GetJob(string pipelineId, string experimentId)
    {
        var request = new RestRequest($"pipelineruns/{pipelineId}/status?experimentId={experimentId}");
        return await _jobClient.GetAsync<JobGetResponeEntity>(request) ?? throw new InvalidOperationException();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}