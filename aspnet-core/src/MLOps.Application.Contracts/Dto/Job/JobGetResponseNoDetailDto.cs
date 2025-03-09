using System.Collections.Generic;
using MLOps.Dto.Pipeline;
using Volo.Abp.Application.Dtos;

namespace MLOps.Dto.Job;

public class JobGetResponseNoDetailDto: EntityDto
{
    public string PipelineId { get; set; }
    public string RunSource { get; set; }
    public int RunType { get; set; }
    public int TotalSteps { get; set; }
    public Dictionary<string, string> Logs { get; set; }
    public bool ContinueRunOnFailedOptionalInput { get; set; }
    public bool ContinueRunOnStepFailure { get; set; }
    public string Description { get; set; }
    public string DisplayName { get; set; }
    public int StatusCode { get; set; }
    public string RunStatus { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string GraphId { get; set; }
    public string ExperimentName { get; set; }
    public string SubmittedBy { get; set; }
    public Dictionary<string, string> Tags { get; set; }
    public Dictionary<string, string> StepTags { get; set; }
    public Dictionary<string, string> Properties { get; set; }
    public string AetherStartTime { get; set; }
    public string AetherEndTime { get; set; }
    public string RunHistoryStartTime { get; set; }
    public string RunHistoryEndTime { get; set; }
    public int EntityStatus { get; set; }
    public string Id { get; set; }
    public PipelineResponseParametrAssignemtetsDto Parameters { get; set; }
}