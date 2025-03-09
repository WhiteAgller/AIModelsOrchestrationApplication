namespace MLOps.SharedEntities.PipelineShared;

public class PipelineResponseCreatedBy
{
    public string UserObjectId { get; set; }
    public string UserTenantId { get; set; }
    public string UserName { get; set; }
}

public class PipelineResponseStatus
{
    public int StatusCode { get; set; }
    public string StatusDetail { get; set; }
    public string CreationTime { get; set; }
    public string EndTime { get; set; }
}

public class PipelineResponseDataPathAssignments
{
    
}


public class AssetOutputSettingsAssignments
{
    //IS FOR NOW TEMPORARY EMPTY
}

public class DefaultCompute
{
    public string Name { get; set; }
    public object ComputeType { get; set; }
    public string BatchAiComputeInfo { get; set; }
    public string RemoteDockerComputeInfo { get; set; }
    public string HdiClusterComputeInfo { get; set; }
    public MlcComputeInfo MlcComputeInfo { get; set; }
    public object  DatabricksComputeInfo { get; set; }
}

public class MlcComputeInfo
{
    public string MLCComputeType { get; set; }
}

public class DefaultDatastore
{
    public string DataStoreName { get; set; } 
}

public class AssetDefinitionObj
{
    public virtual string LiteralValue { get; set; }
    public virtual string DataSetReference { get; set; }
    public virtual string SavedDataSetReference { get; set; }
    public virtual string AssetReference { get; set; }
    public virtual AssetDefinitionAsset AssetDefinition { get; set; }
}

public class AssetDefinitionAsset
{
    public virtual string Path { get; set; }
    public virtual int Type { get; set; }
    public virtual string AssetId { get; set; }
    public virtual string SerializedAssetId { get; set; }
}