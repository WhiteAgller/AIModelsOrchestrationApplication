using System.Threading.Tasks;
using MLOps.Config;
using Volo.Abp.Domain.Services;

namespace MLOps.Azure.Blob;

public interface IAzureBlobClient : IDomainService
{
   Task<string> GetTrainData(string pipelineId);
   
   Task<string> GetTestData(string pipelineId);

   Task<string> GetModel(string pipelineId);

}