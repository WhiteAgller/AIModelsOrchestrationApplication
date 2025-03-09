using Volo.Abp.Application.Dtos;

namespace MLOps.Dto.Model;

public class ModelGetDetailDto : EntityDto
{
    public virtual string ModelName { get; set; }
    public virtual string ModelVersion { get; set; }
}