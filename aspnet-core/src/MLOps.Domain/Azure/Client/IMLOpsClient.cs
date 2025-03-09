using System.Collections.Generic;
using System.Threading.Tasks;
using MLOps.Config;
using MLOps.Entities;
using MLOps.Entities.Dataset;
using MLOps.Entities.Experiment;
using MLOps.Entities.Job;
using MLOps.Entities.Model;
using Volo.Abp.Domain.Services;

namespace MLOps.Azure.Client;

public interface IMLOpsClient : IDomainService
{
    Task<MlOpsClient> CreateAsync(IConfigHandler configHandler);
    Task<PipelineResponseEntity> RunPipeline(string url, string inputBody);

    Task<List<ExperimentGetResponseEntity>> GetExperiments();
    
    Task<string> GetExperimentId(string experimentName);

    Task<JobGetResponseNoDetailEntity> GetJobNoDetail(string pipelineId);
    Task<JobGetResponeEntity> GetJob(string pipelineId, string experimentId);

    Task<DatasetPutResponseEntity> CreateOrUpdateDataset(string name, string version, string inputBody);

    Task<DatasetGetResponseEntity> GetDatasets();

    Task<DatasetGetVersionsResponseEntity> GetDatasetVersion(string name);

    Task<ModelGetVersionsEntity> GetModelVersions(string modelName);
}