using MLOps.SharedEntities.PipelineShared;
using Volo.Abp.Application.Dtos;

namespace MLOps.Dto.Pipeline;

public class PipelineResponseDto : EntityDto<int>
{
    public virtual string Description { get; set; }
    public virtual PipelineResponseStatus Status { get; set; }
    public virtual string GraphId { get; set; }
    public virtual bool IsSubmitted { get; set; }
    public virtual bool HasErrors { get; set; }
    public virtual bool HasWarnings { get; set; }
    public virtual int UploadState { get; set; }
    public virtual PipelineResponseParametrAssignemtetsDto ParameterAssignments { get; set; }
    public virtual object DataPathAssignments { get; set; }
    public virtual DataSetDefinitionValueAssignmentsDto DataSetDefinitionValueAssignments { get; set; }
    public virtual AssetOutputSettingsAssignments AssetOutputSettingsAssignments { get; set; }
    public virtual string RunHistoryExperimentName { get; set; }
    public virtual string DisplayName { get; set; }
    public virtual string PipelineRunId { get; set; }
    public virtual string PipelineId { get; set; }
    public virtual string PipelineEndpointId { get; set; }
    public virtual string RunSource { get; set; }
    public virtual int RunType { get; set; }
    public virtual int TotalRunSteps { get; set; }
    public virtual string ScheduleId { get; set; }
    public virtual string RunUrl { get; set; }
    public virtual object tags { get; set; }
    public virtual object StepTags { get; set; }
    public virtual object Properties { get; set; }
    public virtual object StepProperties { get; set; }
    public virtual PipelineResponseCreatedBy CreatedBy { get; set; }
    public virtual bool PreserveSubGraphs { get; set; }
    public virtual string RootPipelineRunId { get; set; }
    public virtual string EnforceRerun { get; set; }
    public virtual bool ContinueRunOnFailedOptionalInput { get; set; }
    public virtual string UserAlias { get; set; }
    public virtual string DefaultCloudPriority { get; set; }
    public virtual DefaultCompute DefaultCompute { get; set; }
    public virtual DefaultDatastore DefaultDatastore { get; set; }
    public virtual object IdentityConfig { get; set; }
    public virtual string PipelineTimeoutSeconds { get; set; }
    public virtual bool ContinueRunOnStepFailure { get; set; }
    public virtual int EntityStatus { get; set; }
    public virtual string Etag { get; set; }
    public virtual string CreatedDate { get; set; }
    public virtual string LastModifiedDate { get; set; }
}