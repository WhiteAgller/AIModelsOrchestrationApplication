using System.Collections.Generic;
using MLOps.SharedEntities.Dataset;
using Volo.Abp.Application.Dtos;

namespace MLOps.Dto.Dataset;

public class DatasetGetResponseDto : EntityDto
{
    public List<WorkspaceData> Value { get; set; }
}