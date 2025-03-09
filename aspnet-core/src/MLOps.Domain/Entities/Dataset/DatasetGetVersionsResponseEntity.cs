using System.Collections.Generic;
using MLOps.SharedEntities.Dataset;
using Volo.Abp.Domain.Entities;

namespace MLOps.Entities.Dataset;

public class DatasetGetVersionsResponseEntity: Entity<int>
{
    public List<ValueGetVersions> Value { get; set; }
}