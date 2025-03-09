using System.Collections.Generic;
using MLOps.SharedEntities.Job;
using Volo.Abp.Application.Dtos;

namespace MLOps.Dto.Job;

public class JobGetResponeDto: EntityDto
{
    public virtual Status Status { get; set; }
    public virtual Dictionary<string, NodesStatus> GraphNodesStatus { get; set; }
    public virtual string ExperimentId { get; set; }
    public virtual bool IsExperimentArchived { get; set; }
}