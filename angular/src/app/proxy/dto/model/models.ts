import type { EntityDto } from '@abp/ng.core';
import type { Version } from '../../shared-entities/model/models';

export interface ModelGetDetailDto extends EntityDto {
  modelName?: string;
  modelVersion?: string;
}

export interface ModelGetVersionsDto extends EntityDto {
  value: Version[];
}

export interface ModelsInfoDto extends EntityDto {
  id?: string;
  port?: string;
  name?: string;
  lastUpdate?: Date;
  version?: string;
  accuracy: number;
  pipelineName?: string;
  environmentName?: string;
}
