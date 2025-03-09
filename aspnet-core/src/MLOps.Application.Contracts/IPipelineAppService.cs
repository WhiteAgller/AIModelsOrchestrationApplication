using System.Threading.Tasks;
using MLOps.Dto.Pipeline;
using Volo.Abp.Application.Services;

namespace MLOps;

public interface IPipelineAppService : IApplicationService
{
    Task<PipelineResponseDto> RunPipelineAsync(PipelineBodyDto input);
    
    Task<string> GetTrainData(string pipelineId);
     
    Task<string> GetTestData(string pipelineId);
    
}