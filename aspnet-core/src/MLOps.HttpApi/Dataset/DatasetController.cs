using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MLOps.Dto.Dataset;
using MLOps.Dto.Pipeline;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace MLOps.Dataset;

[Area(MLOpsRemoteServiceConsts.ModuleName)]
[RemoteService(Name = MLOpsRemoteServiceConsts.RemoteServiceName)]
[Route("api/MLOps/dataset")]
public class DatasetController: IDatasetAppService
{
    private readonly IDatasetAppService _datasetAppService;

    public DatasetController(IDatasetAppService datasetAppService)
    {
        _datasetAppService = datasetAppService;
    }
    
    [HttpPut]
    [Route("create")]
    public async Task<DatasetPutResponseDto> CreateOrUpdateDataset(DatasetPutRequesetDto input)
    {
        return await _datasetAppService.CreateOrUpdateDataset(input);
    }

    [HttpGet]
    [Route("vse")]
    public async Task<DatasetGetResponseDto> GetDatasets()
    {
        return await _datasetAppService.GetDatasets();
    }
}