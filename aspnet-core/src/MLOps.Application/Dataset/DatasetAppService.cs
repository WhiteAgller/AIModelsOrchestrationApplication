using System.Threading.Tasks;

using MLOps;
using MLOps.Azure.Client;
using MLOps.Config;
using MLOps.Converter;
using MLOps.Dto.Dataset;
using MLOps.Entities.Dataset;
using MLOps.SharedEntities.Dataset;
using Newtonsoft.Json;
using Volo.Abp.ObjectMapping;

namespace MLOps.Dataset;

public class DatasetAppService : MLOpsAppService, IDatasetAppService
{
    private readonly IURLConverter _urlConverter;
    private readonly IMLOpsClient _mlOpsClient;
    private readonly IConfigHandler _configHandler;

    public DatasetAppService(IURLConverter urlConverter, IMLOpsClient mlOpsClient, IConfigHandler configHandler)
    {
        _urlConverter = urlConverter;
        _mlOpsClient = mlOpsClient;
        _configHandler = configHandler;
    }

    public async Task<DatasetPutResponseDto> CreateOrUpdateDataset(DatasetPutRequesetDto input)
    {
        var client = await _mlOpsClient.CreateAsync(_configHandler);
        
        var body = CreateDatasetBodyDto(input);
        var inputString = JsonConvert.SerializeObject(body);

        var submitResponse = await client.CreateOrUpdateDataset(input.NewDatasetName, input.NewDatasetVersion, inputString);
        
        return ObjectMapper.Map<DatasetPutResponseEntity, DatasetPutResponseDto>(submitResponse);
    }

    public async Task<DatasetGetResponseDto> GetDatasets()
    {
        var client = await _mlOpsClient.CreateAsync(_configHandler);
        var submitResponse = await client.GetDatasets();
        return ObjectMapper.Map<DatasetGetResponseEntity, DatasetGetResponseDto>(submitResponse);
    }

    private async Task <DatasetPutRequesetAzureDto> CreateDatasetBodyDto(DatasetPutRequesetDto input)
    {
        var p = new Properties()
        {
            Description = input.Description,
            DataUri = await _urlConverter.ConvertURLtoURI(input.DataStoreUrl),
            DataType = input.DataType
        };
        
        return new DatasetPutRequesetAzureDto()
        {
            Properties = p
        };
    }

}