using System.Collections.Generic;
using MLOps.SharedEntities.Job;
using Volo.Abp.Domain.Entities;

namespace MLOps.Entities.Job;

public class JobGetResponeEntity: Entity<int>
{
    public virtual Status Status { get; set; }
    public virtual Dictionary<string, NodesStatus> GraphNodesStatus { get; set; }
    
    public virtual string ExperimentId { get; set; }
    
    public virtual bool IsExperimentArchived { get; set; }
}
