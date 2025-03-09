using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MLOps.Dto.Model;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace MLOps.Model;

[Area(MLOpsRemoteServiceConsts.ModuleName)]
[RemoteService(Name = MLOpsRemoteServiceConsts.RemoteServiceName)]
[Route("api/MLOps/model")]
public class ModelController : MLOpsController, IModelAppService
{
    private readonly IModelAppService _modelAppService;

    public ModelController(IModelAppService modelAppService)
    {
        _modelAppService = modelAppService;
    }

    [HttpGet]
    [Route("")]
    public async Task<string> GetModel([Required] string pipelineId)
    {
        return await _modelAppService.GetModel(pipelineId);
    }
    
    [HttpGet]
    [Route("versions/vse")]
    public async Task<ModelGetVersionsDto> GetModelVersions(string pipelineId)
    {
        return await _modelAppService.GetModelVersions(pipelineId);
    }
    
    [HttpGet]
    [Route("version/latest")]
    public async Task<ModelGetDetailDto> GetModelLatestVersion(string pipelineId)
    {
        return await _modelAppService.GetModelLatestVersion(pipelineId);
    }
    
    [HttpPost]
    [Route("deploy")]
    public async Task<string> DeployModel([Required] string pipelineId, [Required] string port, [Required] string pipelineName)
    {
        return await _modelAppService.DeployModel(pipelineId, port, pipelineName);
    }
    
}