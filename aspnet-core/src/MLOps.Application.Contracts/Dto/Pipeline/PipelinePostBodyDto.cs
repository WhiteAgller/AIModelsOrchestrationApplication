using Volo.Abp.Application.Dtos;

namespace MLOps.Dto.Pipeline;

public class PipelinePostBodyDto : PipelineBodyDto
{
    public virtual DataSetDefinitionValueAssignmentsDto DataSetDefinitionValueAssignments { get; set; }
}

public class PipelineBodyDto : EntityDto
{
    public virtual string PipelineUrl { get; set; }
    public virtual string DatasetName { get; set; }
    public virtual string DatasetVersion { get; set; }
    public virtual string ExperimentName { get; set; }
    public virtual string Description { get; set; }
    public virtual string DisplayName { get; set; }
    public virtual PipelineParametrAssignemtetsDto ParameterAssignments { get; set; }
}

public class PipelineParametrAssignemtetsDto : EntityDto
{
    // No parameters to specify, defaults are set
}