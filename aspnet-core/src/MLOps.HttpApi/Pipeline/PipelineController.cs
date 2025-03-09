using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MLOps.Dto.Pipeline;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace MLOps.Pipeline;

[Area(MLOpsRemoteServiceConsts.ModuleName)]
[RemoteService(Name = MLOpsRemoteServiceConsts.RemoteServiceName)]
[Route("api/MLOps/pipeline")]
public class PipelineController : MLOpsController, IPipelineAppService
{
    private readonly IPipelineAppService _pipelineAppService;

    public PipelineController(IPipelineAppService pipelineAppService)
    {
        _pipelineAppService = pipelineAppService;
    }
    
    [HttpPost]
    [Route("run")]
    public async Task<PipelineResponseDto> RunPipelineAsync([Required] PipelineBodyDto input)
    {
        return await _pipelineAppService.RunPipelineAsync(input);
    }
    
    [HttpGet]
    [Route("trainData")]
    public async Task<string> GetTrainData([Required] string pipelineId)
    {
        return await _pipelineAppService.GetTrainData(pipelineId);
    }
    
    [HttpGet]
    [Route("testData")]
    public async Task<string> GetTestData([Required] string pipelineId)
    {
        return await _pipelineAppService.GetTestData(pipelineId);
    }
}