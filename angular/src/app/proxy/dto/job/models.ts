import type { EntityDto } from '@abp/ng.core';
import type { NodesStatus, Status } from '../../shared-entities/job/models';

export interface JobGetResponeDto extends EntityDto {
  status: Status;
  graphNodesStatus: Record<string, NodesStatus>;
  experimentId?: string;
  isExperimentArchived: boolean;
}

export interface JobStatusDto extends EntityDto {
  id?: string;
  displayName?: string;
  pipelineId?: string;
  experimentId?: string;
}
