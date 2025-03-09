
export interface NodesStatus {
  status: number;
  runStatus?: string;
  isBypassed: boolean;
  hasFailedChildRun: boolean;
  partiallyExecuted: boolean;
  properties: Record<string, string>;
  runHistoryStartTime?: string;
  runHistoryEndTime?: string;
  runHistoryCreationTime?: string;
  reuseInfo: ReuseInfo;
  statusCode: number;
  statusDetail?: string;
  creationTime?: string;
  startTime?: string;
  endTime?: string;
  runId?: string;
  dataContainerId?: string;
  hasWarnings: boolean;
}

export interface ReuseInfo {
  experimentId?: string;
  pipelineRunId?: string;
  nodeId?: string;
  runId?: string;
  nodeStartTime?: string;
  nodeEndTime?: string;
}

export interface Status {
  statusCode: number;
  runStatus?: string;
  startTime?: string;
  endTime?: string;
  isTerminalState: boolean;
}
