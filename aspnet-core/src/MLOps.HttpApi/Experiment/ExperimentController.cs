using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MLOps.Dto.Experiment;
using MLOps.Dto.Job;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace MLOps.Experiment;

[Area(MLOpsRemoteServiceConsts.ModuleName)]
[RemoteService(Name = MLOpsRemoteServiceConsts.RemoteServiceName)]
[Route("api/MLOps/experiment")]
public class ExperimentController: MLOpsController, IExperimentAppService
{
    private readonly IExperimentAppService _experimentAppService;

    public ExperimentController(IExperimentAppService experimentAppService )
    {
        _experimentAppService = experimentAppService;
    }
    
    [HttpGet]
    [Route("vse")]
    public async Task<List<ExperimentGetResponseDto>> GetAllExperiments()
    {
        return await _experimentAppService.GetAllExperiments();
    }
    
    [HttpGet]
    [Route("")]
    public async Task<string> GetExperimentId([Required] string experimentName)
    {
        return await _experimentAppService.GetExperimentId(experimentName);
    }

}