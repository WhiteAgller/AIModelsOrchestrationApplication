import type { EntityDto } from '@abp/ng.core';
import type { AssetDefinitionObj, AssetOutputSettingsAssignments, DefaultCompute, DefaultDatastore, PipelineResponseCreatedBy, PipelineResponseStatus } from '../../shared-entities/pipeline-shared/models';
import type { ModelType } from '../../model-type.enum';

export interface DataSetDefinitionValueAssignmentsDto extends EntityDto {
  pipeline_job_data_input: AssetDefinitionObj;
}

export interface PipelineBodyDto extends EntityDto {
  pipelineUrl?: string;
  datasetName?: string;
  datasetVersion?: string;
  experimentName?: string;
  description?: string;
  displayName?: string;
  parameterAssignments: PipelineParametrAssignemtetsDto;
}

export interface PipelineEndpointDto extends EntityDto {
  id?: string;
  name?: string;
  type: ModelType;
  restEndpoint?: string;
}

export interface PipelineParametrAssignemtetsDto extends EntityDto {
}

export interface PipelineResponseDto extends EntityDto<number> {
  description?: string;
  status: PipelineResponseStatus;
  graphId?: string;
  isSubmitted: boolean;
  hasErrors: boolean;
  hasWarnings: boolean;
  uploadState: number;
  parameterAssignments: PipelineResponseParametrAssignemtetsDto;
  dataPathAssignments: object;
  dataSetDefinitionValueAssignments: DataSetDefinitionValueAssignmentsDto;
  assetOutputSettingsAssignments: AssetOutputSettingsAssignments;
  runHistoryExperimentName?: string;
  displayName?: string;
  pipelineRunId?: string;
  pipelineId?: string;
  pipelineEndpointId?: string;
  runSource?: string;
  runType: number;
  totalRunSteps: number;
  scheduleId?: string;
  runUrl?: string;
  tags: object;
  stepTags: object;
  properties: object;
  stepProperties: object;
  createdBy: PipelineResponseCreatedBy;
  preserveSubGraphs: boolean;
  rootPipelineRunId?: string;
  enforceRerun?: string;
  continueRunOnFailedOptionalInput: boolean;
  userAlias?: string;
  defaultCloudPriority?: string;
  defaultCompute: DefaultCompute;
  defaultDatastore: DefaultDatastore;
  identityConfig: object;
  pipelineTimeoutSeconds?: string;
  continueRunOnStepFailure: boolean;
  entityStatus: number;
  etag?: string;
  createdDate?: string;
  lastModifiedDate?: string;
}

export interface PipelineResponseParametrAssignemtetsDto extends EntityDto {
  pipeline_job_test_train_ratio?: string;
  pipeline_job_learning_rate?: string;
  pipeline_job_registered_model_name?: string;
}
