using MLOps.SharedEntities.Dataset;
using Volo.Abp.Application.Dtos;

namespace MLOps.Dto.Dataset;

public class DatasetPutResponseDto : EntityDto<int>
{
    public virtual string Id { get; set; }
    public virtual string Name { get; set; }
    public virtual string Type { get; set; }
    public virtual Properties Properties { get; set; }
    public virtual SystemData SystemData { get; set; }
}