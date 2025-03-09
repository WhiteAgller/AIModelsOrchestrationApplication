using System;
using Volo.Abp.Application.Dtos;

namespace MLOps.Dto.Job;

public class JobStatusDto: EntityDto
{
    public virtual Guid Id { get; set; }
    public virtual string DisplayName { get; set; }
    public virtual string PipelineId { get; set; }
    public virtual string ExperimentId { get; set; }
}