using System.Text.Json.Serialization;
using MLOps.SharedEntities.PipelineShared;
using Volo.Abp.Domain.Entities;

namespace MLOps.Entities;

public class DataSetDefinitionValueAssignmentsEntity : Entity<int>
{
    [JsonPropertyName("pipeline_job_data_input")]
    public virtual AssetDefinitionObj DataInput { get; set; }
}
