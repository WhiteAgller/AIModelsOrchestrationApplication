using System.Text.Json.Serialization;
using Volo.Abp.Domain.Entities;

namespace MLOps.Entities;

public class PipelineResponseParametrAssignemtetsEntity : Entity<int>
{
    [JsonPropertyName("pipeline_job_test_train_ratio")]
    public virtual string TestTrainRatio { get; set; }
    
    [JsonPropertyName("pipeline_job_learning_rate")]
    public virtual string LearningRate { get; set; }
    
    [JsonPropertyName("pipeline_job_registered_model_name")]
    public virtual string ModelName { get; set; }
}

public class PipelineParametrAssignemtetsEntity
{
    
}