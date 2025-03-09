using System.Collections.Generic;
using MLOps.SharedEntities.Model;
using Volo.Abp.Application.Dtos;

namespace MLOps.Dto.Model;

public class ModelGetVersionsDto: EntityDto
{
    public List<Version> Value { get; set; }
}

