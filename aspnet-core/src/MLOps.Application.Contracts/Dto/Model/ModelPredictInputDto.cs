using System;
using Volo.Abp.Application.Dtos;

namespace MLOps.Dto.Model;

public class ModelPredictInputDto: EntityDto
{
    public virtual Object[] Input { get; set; } 
}