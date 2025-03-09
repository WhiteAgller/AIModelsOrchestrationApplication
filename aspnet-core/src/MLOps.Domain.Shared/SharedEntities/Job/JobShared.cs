using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MLOps.SharedEntities.Job;

public class Status
{
    public virtual int StatusCode { get; set; }
    public virtual string RunStatus { get; set; }
    public virtual string StartTime { get; set; }
    public virtual string EndTime { get; set; }
    public virtual bool IsTerminalState { get; set; }
}

public class NodesStatus 
{
    public int Status { get; set; }
    public string RunStatus { get; set; }
    public bool IsBypassed { get; set; }
    public bool HasFailedChildRun { get; set; }
    public bool PartiallyExecuted { get; set; }
    public Dictionary<string, string> Properties { get; set; }
    public DateTime RunHistoryStartTime { get; set; }
    public DateTime RunHistoryEndTime { get; set; }
    public DateTime RunHistoryCreationTime { get; set; }
    public ReuseInfo ReuseInfo { get; set; }
    public int StatusCode { get; set; }
    public string StatusDetail { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string RunId { get; set; }
    public string DataContainerId { get; set; }
    public bool HasWarnings { get; set; }
    
}

public class Properties
{
    [JsonPropertyName("azureml_isreused")]
    public string IsReused { get; set; }

    [JsonPropertyName("azureml_reusedrunid")]
    public string ReusedRunId { get; set; }

    [JsonPropertyName("azureml_reusednodeid")]
    public string ReusedNodeId { get; set; }

    [JsonPropertyName("azureml_reusedpipeline")]
    public string ReusedPipeline { get; set; }

    [JsonPropertyName("azureml_reusedpipelinerunid")]
    public string ReusedPipelineRunId { get; set; }

    [JsonPropertyName("azureml_runsource")]
    public string RunSource { get; set; }

    [JsonPropertyName("azureml_nodeid")]
    public string NodeId { get; set; }

    public string ContentSnapshotId { get; set; }

    public string StepType { get; set; }

    [JsonPropertyName("azureml_computetargettype")]
    public string ComputeTargetType { get; set; }

    [JsonPropertyName("azureml_moduleid")]
    public string ModuleId { get; set; }

    [JsonPropertyName("azureml_modulename")]
    public string ModuleName { get; set; }

    [JsonPropertyName("azureml_pipeline")]
    public string Pipeline { get; set; }

    [JsonPropertyName("azureml_pipelinerunid")]
    public string PipelineRunId { get; set; }

    [JsonPropertyName("azureml_pipelineid")]
    public string PipelineId { get; set; }

    [JsonPropertyName("azureml_devplatv2")]
    public string DevPlatv2 { get; set; }

    [JsonPropertyName("azureml_pipelinecomponent")]
    public string PipelineComponent { get; set; }

    [JsonPropertyName("_azureml_computetargettype")]
    public string _ComputeTargetType { get; set; }

    public string ProcessInfoFile { get; set; }

    public string ProcessStatusFile { get; set; }
}

public class ReuseInfo
{
    public string ExperimentId { get; set; }
    public string PipelineRunId { get; set; }
    public string NodeId { get; set; }
    public string RunId { get; set; }
    public DateTime NodeStartTime { get; set; }
    public DateTime NodeEndTime { get; set; }
}