using System.Threading.Tasks;
using MLOps.Dto.Dataset;
using Volo.Abp.Application.Services;

namespace MLOps;

public interface IDatasetAppService : IApplicationService
{
     Task<DatasetPutResponseDto> CreateOrUpdateDataset(DatasetPutRequesetDto input);

     Task<DatasetGetResponseDto> GetDatasets();

}