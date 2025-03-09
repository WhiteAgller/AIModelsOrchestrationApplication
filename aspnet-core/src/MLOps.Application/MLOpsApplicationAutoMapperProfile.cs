using AutoMapper;
using MLOps.Dto.Config;
using MLOps.Dto.Dataset;
using MLOps.Dto.Experiment;
using MLOps.Dto.Job;
using MLOps.Dto.Model;
using MLOps.Dto.Pipeline;
using MLOps.Entities;
using MLOps.Entities.Config;
using MLOps.Entities.Dataset;
using MLOps.Entities.Experiment;
using MLOps.Entities.Job;
using MLOps.Entities.Model;
using Volo.Abp.AutoMapper;

namespace MLOps;

public class MLOpsApplicationAutoMapperProfile : Profile
{
    public MLOpsApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        
        // Pipeline
        CreateMap<PipelineResponseDto, PipelineResponseEntity>().ReverseMap();
        CreateMap<DataSetDefinitionValueAssignmentsEntity, DataSetDefinitionValueAssignmentsDto>().ReverseMap().Ignore(x => x.Id);
        CreateMap<PipelineParametrAssignemtetsDto, PipelineParametrAssignemtetsEntity>().ReverseMap();
        CreateMap<PipelineResponseParametrAssignemtetsEntity, PipelineResponseParametrAssignemtetsDto>().ReverseMap().Ignore(x => x.Id);
        CreateMap<DataSetDefinitionValueAssignmentsEntity, DataSetDefinitionValueAssignmentsDto>().ReverseMap().Ignore(x => x.Id);
        CreateMap<PipelineEndpointEntity, PipelineEndpointDto>().ReverseMap().Ignore(x => x.Id);
        
        // Dataset
        CreateMap<DatasetPutResponseDto, DatasetPutResponseEntity>().ReverseMap();
        CreateMap<DatasetGetResponseEntity, DatasetGetResponseDto>().ReverseMap().Ignore(x => x.Id);
        
        // Job
        CreateMap<JobGetResponeEntity, JobGetResponeDto>().ReverseMap().Ignore(x => x.Id);
        CreateMap<JobGetResponseNoDetailEntity, JobGetResponseNoDetailDto>().ReverseMap();
        
        // Experiment
        CreateMap<ExperimentGetResponseEntity, ExperimentGetResponseDto>().ReverseMap().Ignore(x => x.Id);
        
        // Model
        CreateMap<ModelGetVersionsEntity, ModelGetVersionsDto>().ReverseMap().Ignore(x => x.Id);
        CreateMap<ModelsInfoEntity, ModelsInfoDto>().ReverseMap().Ignore(x => x.Id);
        
        //Config
        CreateMap<ConfigEntity, ConfigDto>().ReverseMap().Ignore(x => x.Id);
    }
}
