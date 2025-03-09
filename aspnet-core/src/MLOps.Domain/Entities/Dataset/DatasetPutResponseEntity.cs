using MLOps.SharedEntities.Dataset;
using Volo.Abp.Domain.Entities;

namespace MLOps.Entities.Dataset;

public class DatasetPutResponseEntity : Entity<int>
{
    public virtual string Id { get; set; }
    public virtual string Name { get; set; }
    public virtual string Type { get; set; }
    public virtual Properties Properties { get; set; }
    public virtual SystemData SystemData { get; set; }
}