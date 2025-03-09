using System.Collections.Generic;
using System.Threading.Tasks;
using MLOps.Dto.Experiment;
using Volo.Abp.Application.Services;

namespace MLOps;

public interface IExperimentAppService : IApplicationService
{
    Task<List<ExperimentGetResponseDto>> GetAllExperiments();

    Task<string> GetExperimentId(string experimentName);
}