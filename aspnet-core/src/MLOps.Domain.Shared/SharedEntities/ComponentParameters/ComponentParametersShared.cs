using System.Text.Json.Serialization;

namespace MLOps.SharedEntities.ComponentParameters;

public class PipelineInput
{
    [JsonPropertyName("pipeline_job_data_input")]
    public virtual string InputData { get; set; }
}

public record DataPreperationJob
{
    [JsonPropertyName("pipeline_job_test_train_ratio")]
    public virtual string TestTrainRatio { get; set; }
}

public record TrainingJob
{
    [JsonPropertyName("pipeline_job_registered_model_name")]
    public virtual string ModelName { get; set; }
    
    [JsonPropertyName("pipeline_job_learning_rate")]
    public virtual string LearningRate { get; set; }
}
