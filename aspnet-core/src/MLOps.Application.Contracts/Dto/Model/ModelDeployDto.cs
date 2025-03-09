using System;
using Volo.Abp.Application.Dtos;

namespace MLOps.Dto.Model;

public class ModelDeployDto : EntityDto
{
    public virtual string PipelineId { get; set; }
    
    public virtual string PipelineName { get; set; }
    
    public virtual string Model { get; set; }
    
    public virtual string TestData { get; set; }
    
    public virtual string TrainData { get; set; }
    
    public virtual string ModelName { get; set; }
    
    public virtual string ModelVersion { get; set; }
}
