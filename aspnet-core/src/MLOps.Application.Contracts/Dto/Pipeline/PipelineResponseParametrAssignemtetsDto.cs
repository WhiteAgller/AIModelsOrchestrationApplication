using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;

namespace MLOps.Dto.Pipeline;

public class PipelineResponseParametrAssignemtetsDto : EntityDto
{
    [JsonPropertyName("pipeline_job_test_train_ratio")]
    public virtual string TestTrainRatio { get; set; }
    
    [JsonPropertyName("pipeline_job_learning_rate")]
    public virtual string LearningRate { get; set; }
    
    [JsonPropertyName("pipeline_job_registered_model_name")]
    public virtual string ModelName { get; set; }
}
