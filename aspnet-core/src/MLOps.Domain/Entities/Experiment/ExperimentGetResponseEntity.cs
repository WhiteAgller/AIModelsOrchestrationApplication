using Volo.Abp.Domain.Entities;

namespace MLOps.Entities.Experiment;

public class ExperimentGetResponseEntity: Entity<int>
{
    public virtual string ExperimentName { get; set; }
    public virtual string ExperimentId { get; set; }
}
