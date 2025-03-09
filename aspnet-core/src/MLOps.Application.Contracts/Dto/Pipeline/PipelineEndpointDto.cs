using System;
using Volo.Abp.Application.Dtos;

namespace MLOps.Dto.Pipeline;

public class PipelineEndpointDto: EntityDto
{
    public virtual Guid Id { get; set; }
    public virtual string Name { get; set; }
    
    public virtual ModelType Type { get; set; }
    public virtual string RestEndpoint { get; set; }
}