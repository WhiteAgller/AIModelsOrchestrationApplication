using System.Collections.Generic;
using MLOps.SharedEntities.Model;
using Volo.Abp.Domain.Entities;

namespace MLOps.Entities.Model;

public class ModelGetVersionsEntity: Entity<int>
{
    public List<Version> Value { get; set; }
}
