using System.Threading.Tasks;
using MLOps.Dto.Model;
using MLOps.Dto.Pipeline;
using Volo.Abp.Application.Services;

namespace MLOps;

public interface IModelAppService : IApplicationService
{
    Task<string> GetModel(string pipelineId);

    Task<ModelGetVersionsDto> GetModelVersions(string modelName);
    
    Task<ModelGetDetailDto> GetModelLatestVersion(string modelName);
        
    Task<string> DeployModel(string pipelineId, string port, string pipelineName);
}