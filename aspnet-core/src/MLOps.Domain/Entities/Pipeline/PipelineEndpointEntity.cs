using System;
using Volo.Abp.Domain.Entities;

namespace MLOps.Entities;

public class PipelineEndpointEntity : BasicAggregateRoot<Guid>
{
    public virtual string Name { get; set; } 
    
    public virtual ModelType Type { get; set; }
    public virtual string RestEndpoint { get; set; } 
}