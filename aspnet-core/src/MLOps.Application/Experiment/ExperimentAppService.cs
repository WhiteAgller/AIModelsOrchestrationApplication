using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MLOps.Azure.Client;
using MLOps.Config;
using MLOps.Dto.Experiment;
using MLOps.Entities.Experiment;

namespace MLOps.Experiment;

public class ExperimentAppService : MLOpsAppService, IExperimentAppService
{
    private readonly IMLOpsClient _mlOpsClient;
    private readonly IConfigHandler _configHandler;
    
    public ExperimentAppService(IMLOpsClient mlOpsClient, IConfigHandler configHandler)
    {
        _mlOpsClient = mlOpsClient;
        _configHandler = configHandler;
    }
    public async Task<List<ExperimentGetResponseDto>> GetAllExperiments()
    {
        var client = await _mlOpsClient.CreateAsync(_configHandler);
        var result = await client.GetExperiments();
        return ObjectMapper.Map<List<ExperimentGetResponseEntity>, List<ExperimentGetResponseDto>>(result);
    }

    public async Task<string> GetExperimentId(string experimentName)
    {
        var client = await _mlOpsClient.CreateAsync(_configHandler);
        var result = await client.GetExperimentId(experimentName);
        return result;
    }
}