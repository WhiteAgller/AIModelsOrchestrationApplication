using System.Collections.Generic;
using System.Threading.Tasks;
using MLOps.Dto.Job;
using Volo.Abp.Application.Services;

namespace MLOps;

public interface IJobAppService : IApplicationService
{
    Task<JobGetResponeDto> GetJob(string pipelineId, string experimentId);

}