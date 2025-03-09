using System.Collections.Generic;
using MLOps.SharedEntities.Dataset;
using Volo.Abp.Domain.Entities;

namespace MLOps.Entities.Dataset;

public class DatasetGetResponseEntity : Entity<int>
{
    public List<WorkspaceData> Value { get; set; }
}