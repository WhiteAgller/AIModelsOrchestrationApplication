using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using MLOps.Azure.Blob;
using MLOps.Azure.Client;
using MLOps.Config;
using MLOps.Consts;
using MLOps.Dto.Pipeline;
using MLOps.Entities;
using MLOps.SharedEntities.PipelineShared;
using Newtonsoft.Json;
using Volo.Abp.Domain.Repositories;


namespace MLOps.Pipeline;

public class PipelineAppService : MLOpsAppService, IPipelineAppService
{
    private readonly IAzureBlobClient _blobClient;
    private readonly IMLOpsClient _mlOpsClient;
    private readonly IRepository<PipelineEndpointEntity, Guid> _pipelineEndpointRepository;
    private readonly IConfigHandler _configHandler;
    
    public PipelineAppService(IAzureBlobClient blobClient, IMLOpsClient mlOpsClient, IRepository<PipelineEndpointEntity, Guid> pipelineEndpointRepository, IConfigHandler configHandler)
    {
        _blobClient = blobClient;
        _mlOpsClient = mlOpsClient;
        _pipelineEndpointRepository = pipelineEndpointRepository;
        _configHandler = configHandler;
    }
    public async Task<PipelineResponseDto> RunPipelineAsync(PipelineBodyDto input)
    {
        var client = await _mlOpsClient.CreateAsync(_configHandler);
        
        var postBodyInput = await CreatePipelinePostBodyDto(input);
        var inputString = JsonConvert.SerializeObject(postBodyInput);
        var url = input.PipelineUrl; 
            
        var submitResponse = await client.RunPipeline(url, inputString);

        return ObjectMapper.Map<PipelineResponseEntity, PipelineResponseDto>(submitResponse);
    }

    private async Task<PipelinePostBodyDto> CreatePipelinePostBodyDto(PipelineBodyDto input)
    {
        var workspaceId = await _configHandler.GetConfigItem(Configuration.WorkspaceId);
        
        var dataSetDefinitionValueAssignments = new DataSetDefinitionValueAssignmentsDto();
        var assetDefinitionObj = new AssetDefinitionObj();
        var assetDefinitionAsset = new AssetDefinitionAsset();
        var asset =
            $"azureml://locations/westeurope/workspaces/{workspaceId}/data/{input.DatasetName}/versions/{input.DatasetVersion}";

        dataSetDefinitionValueAssignments.DataInput = assetDefinitionObj;
        assetDefinitionObj.AssetDefinition = assetDefinitionAsset;
        assetDefinitionAsset.AssetId = asset;

        PipelinePostBodyDto postBodyInput = new PipelinePostBodyDto
        {
            ExperimentName = input.ExperimentName,
            Description = input.Description,
            DisplayName = input.DisplayName,
            ParameterAssignments = input.ParameterAssignments,
            DataSetDefinitionValueAssignments = dataSetDefinitionValueAssignments
        };
        return postBodyInput;
    }
    
    public Task<string> GetTrainData(string pipelineId)
    {
        return _blobClient.GetTrainData(pipelineId);
    }
    
    public Task<string> GetTestData(string pipelineId)
    {
        return _blobClient.GetTestData(pipelineId);
    }
    
    public async Task<List<PipelineEndpointDto>> GetListAsync()
    {
        var items = await _pipelineEndpointRepository.GetListAsync();
        return items
            .Select(item => new PipelineEndpointDto
            {
                Id = item.Id,
                Name = item.Name,
                Type = item.Type,
                RestEndpoint = item.RestEndpoint
            }).ToList();
    }
    
    public async Task<PipelineEndpointDto> CreateAsync(PipelineEndpointDto input)
    {
        var item = await _pipelineEndpointRepository.InsertAsync(
            new PipelineEndpointEntity {Name = input.Name, Type = input.Type, RestEndpoint = input.RestEndpoint}
        );

        return  ObjectMapper.Map<PipelineEndpointEntity, PipelineEndpointDto>(item);
    }
    
    public async Task DeleteAsync(Guid id)
    {
        await _pipelineEndpointRepository.DeleteAsync(id);
    }
}