using System.Text.Json.Serialization;
using MLOps.SharedEntities.PipelineShared;
using Volo.Abp.Application.Dtos;

namespace MLOps.Dto.Pipeline;

public class DataSetDefinitionValueAssignmentsDto : EntityDto
{
    [JsonPropertyName("pipeline_job_data_input")]
    public virtual AssetDefinitionObj DataInput { get; set; }
}