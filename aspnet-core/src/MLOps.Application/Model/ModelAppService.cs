using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MLOps.Azure.Blob;
using MLOps.Azure.Client;
using MLOps.Config;
using MLOps.Dto.Model;
using MLOps.Entities.Model;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace MLOps.Model;

public class ModelAppService : MLOpsAppService, IModelAppService
{
    private readonly IAzureBlobClient _blobClient;
    private readonly IMLOpsClient _mlopsClient;
    private readonly IRepository<ModelsInfoEntity, Guid> _modelsInfoRepository;
    private readonly IConfigHandler _configHandler;
    private readonly ICurrentUser _currentUser;

    private string _host = "localhost";
    private HttpClient _client = new HttpClient();

    public ModelAppService(IAzureBlobClient blobClient,
        IMLOpsClient mlopsClient,
        IRepository<ModelsInfoEntity, Guid> modelsInfoRepository,
        IConfigHandler configHandler,
        ICurrentUser currentUser)
    {
        _blobClient = blobClient;
        _mlopsClient = mlopsClient;
        _modelsInfoRepository = modelsInfoRepository;
        _configHandler = configHandler;
        _currentUser = currentUser;
    }

    public async Task<ModelGetVersionsDto> GetModelVersions(string pipelineId)
    {
        var client = await _mlopsClient.CreateAsync(_configHandler);
        
        var job = await _mlopsClient.GetJobNoDetail(pipelineId);
        var modelName = job.Parameters.ModelName;

        var modelVersions = await client.GetModelVersions(modelName);
        return ObjectMapper.Map<ModelGetVersionsEntity, ModelGetVersionsDto>(modelVersions);

    }

    public async Task<ModelGetDetailDto> GetModelLatestVersion(string pipelineId)
    {
        var client = await _mlopsClient.CreateAsync(_configHandler);
        
        var job = await client.GetJobNoDetail(pipelineId);
        var modelName = job.Parameters.ModelName;

        var modelVersions = await client.GetModelVersions(modelName);
        var result = modelVersions.Value.MaxBy(x => x.Name);

        return new ModelGetDetailDto()
        {
            ModelName = modelName,
            ModelVersion = result.Name
        };
    }

    public async Task<string> DeployModel(string pipelineId, string port, string pipelineName)
    {
        var model = await _blobClient.GetModel(pipelineId);
        var testData = await _blobClient.GetTestData(pipelineId);
        var trainData = await _blobClient.GetTrainData(pipelineId);
        var latestModel = await GetModelLatestVersion(pipelineId);
        
        _client.BaseAddress = new Uri($"http://{_host}:{port}");
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        var pipelineDto = new ModelDeployDto()
        {
            PipelineName = pipelineName,
            Model = model,
            TestData = testData,
            TrainData = trainData,
            ModelName = latestModel.ModelName,
            ModelVersion = latestModel.ModelVersion
        };
        var response = await _client.PostAsJsonAsync(
            "/deployModel", pipelineDto);

        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> Predict(string port, Object[] input)
    {
        _client.BaseAddress = new Uri($"http://{_host}:{port}");
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        var modelDto = new ModelPredictInputDto()
        {
            Input = input
        };
        var response = await _client.PostAsJsonAsync(
            "/predict", input);

        return await response.Content.ReadAsStringAsync();
    }
    
    public async Task<string> GetPerformance(string port, ModelType type, bool json)
    {
        _client.BaseAddress = new Uri($"http://{_host}:{port}");
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await _client.GetAsync($"/performance?type={type}&json={json}");

        return await response.Content.ReadAsStringAsync();
    }
    
    public async Task<string> GetDataDrift(string port)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri($"http://{_host}:{port}");
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await client.GetAsync("/data-drift");

        return await response.Content.ReadAsStringAsync();
    }
    
    public Task<string> GetModel(string pipelineId)
    {
        return _blobClient.GetModel(pipelineId);
    }
    
    public async Task<List<ModelsInfoDto>> GetListAsync()
    {
        var items = await _modelsInfoRepository.GetListAsync();
        return items
            .Select(item => new ModelsInfoDto
            {
                Id = item.Id,
                Name = item.Name,
                Port = item.Port,
                Accuracy = item.Accuracy,
                Version = item.Version,
                LastUpdate = item.LastUpdate,
                PipelineName = item.PipelineName,
                EnvironmentName = item.EnvironmentName
            }).ToList();
    }
    
    public async Task<ModelsInfoDto> CreateAsync(ModelsInfoDto input)
    {
        var item = await _modelsInfoRepository.InsertAsync(
            new ModelsInfoEntity {
                Name = input.Name,
                Port = input.Port,
                Accuracy = input.Accuracy,
                Version = input.Version,
                LastUpdate = input.LastUpdate,
                PipelineName = input.PipelineName,
                EnvironmentName = input.EnvironmentName
                                  
            }
        );
        return ObjectMapper.Map<ModelsInfoEntity, ModelsInfoDto>(item);
    }
    
    public async Task UpdateAsync(ModelsInfoDto input)
    {
        var entity = await _modelsInfoRepository.GetAsync(input.Id);

        if (entity == null)
        {
            throw new Exception("Entity wasn't found");
        }
        entity.Name = input.Name;
        entity.Port = input.Port;
        entity.Accuracy = input.Accuracy;
        entity.Version = input.Version;
        entity.LastUpdate = input.LastUpdate;
        entity.PipelineName = input.PipelineName;
        entity.EnvironmentName = input.EnvironmentName;
        await _modelsInfoRepository.UpdateAsync(entity);

    }
    
    public async Task DeleteAsync(Guid id)
    {
        await _modelsInfoRepository.DeleteAsync(id);
    }
}