using System;
using Volo.Abp.Domain.Entities;

namespace MLOps.Entities.Job;

public class JobStatusEntity: BasicAggregateRoot<Guid>
{
    public virtual string DisplayName { get; set; }
    
    public virtual string PipelineId { get; set; }
    
    public virtual string ExperimentId { get; set; }
}