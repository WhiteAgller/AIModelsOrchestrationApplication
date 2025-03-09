using MLOps.SharedEntities.PipelineShared;
using Volo.Abp.Domain.Entities;

namespace MLOps.Entities;

public class PipelineResponseEntity : Entity<int>
{
    public string Description { get; set; }
    public PipelineResponseStatus Status { get; set; }
    public string GraphId { get; set; }
    public bool IsSubmitted { get; set; }
    public bool HasErrors { get; set; }
    public bool HasWarnings { get; set; }
    public int UploadState { get; set; }
    public PipelineResponseParametrAssignemtetsEntity ParameterAssignments { get; set; }
    public object DataPathAssignments { get; set; }
    public DataSetDefinitionValueAssignmentsEntity DataSetDefinitionValueAssignments { get; set; }
    public AssetOutputSettingsAssignments AssetOutputSettingsAssignments { get; set; }
    public string RunHistoryExperimentName { get; set; }
    public string DisplayName { get; set; }
    public string PipelineRunId { get; set; }
    public string PipelineId { get; set; }
    public string PipelineEndpointId { get; set; }
    public string RunSource { get; set; }
    public int RunType { get; set; }
    public int TotalRunSteps { get; set; }
    public string ScheduleId { get; set; }
    public string RunUrl { get; set; }
    public object tags { get; set; }
    public object StepTags { get; set; }
    public object Properties { get; set; }
    public object StepProperties { get; set; }
    public PipelineResponseCreatedBy CreatedBy { get; set; }
    public bool PreserveSubGraphs { get; set; }
    public string RootPipelineRunId { get; set; }
    public string EnforceRerun { get; set; }
    public bool ContinueRunOnFailedOptionalInput { get; set; }
    public string UserAlias { get; set; }
    public string DefaultCloudPriority { get; set; }
    public DefaultCompute DefaultCompute { get; set; }
    public DefaultDatastore DefaultDatastore { get; set; }
    public object IdentityConfig { get; set; }
    public string PipelineTimeoutSeconds { get; set; }
    public bool ContinueRunOnStepFailure { get; set; }
    public int EntityStatus { get; set; }
    public string Etag { get; set; }
    public string CreatedDate { get; set; }
    public string LastModifiedDate { get; set; }
}
