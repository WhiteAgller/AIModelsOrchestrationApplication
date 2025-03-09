using System.Collections.Generic;
using MLOps.SharedEntities.Dataset;
using Volo.Abp.Application.Dtos;

namespace MLOps.Dto.Dataset;

public class DatasetGetVersionsResponseDto: EntityDto<int>
{
    public List<ValueGetVersions> Value { get; set; }
    public string NextLink { get; set; }
}