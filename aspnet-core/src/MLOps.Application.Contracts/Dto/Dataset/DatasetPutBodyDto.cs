using MLOps.SharedEntities;
using MLOps.SharedEntities.Dataset;

namespace MLOps.Dto.Dataset;

// This dto is for our api
public class DatasetPutRequesetDto : PropertiesDetail
{
    public string NewDatasetName { get; set; }
    
    public string NewDatasetVersion { get; set; }
    public string DataStoreUrl { get; set; }

}

// This dto is for az ml rest api
public class DatasetPutRequesetAzureDto
{
    public Properties Properties { get; set; }
}