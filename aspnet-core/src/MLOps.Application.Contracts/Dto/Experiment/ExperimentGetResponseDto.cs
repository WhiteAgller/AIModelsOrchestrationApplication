using Volo.Abp.Application.Dtos;

namespace MLOps.Dto.Experiment;

public class ExperimentGetResponseDto: EntityDto
{
    public virtual string ExperimentName { get; set; }
    public virtual string ExperimentId { get; set; }
}