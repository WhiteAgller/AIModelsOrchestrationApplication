using System;
using Volo.Abp.Domain.Entities;

namespace MLOps.Entities.Model;

public class ModelsInfoEntity: BasicAggregateRoot<Guid>
{
    public virtual string Port { get; set; }
    public virtual string Name { get; set; }
    public virtual DateTime LastUpdate { get; set; }
    public virtual string Version { get; set; }
    public virtual double Accuracy { get; set; }
    public virtual string PipelineName { get; set; }
    
    public virtual string EnvironmentName { get; set; }
}