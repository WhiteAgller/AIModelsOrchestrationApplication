import type { EntityDto } from '@abp/ng.core';
import type { Properties, PropertiesDetail, SystemData, WorkspaceData } from '../../shared-entities/dataset/models';

export interface DatasetGetResponseDto extends EntityDto {
  value: WorkspaceData[];
}

export interface DatasetPutRequesetDto extends PropertiesDetail {
  newDatasetName?: string;
  newDatasetVersion?: string;
  dataStoreUrl?: string;
}

export interface DatasetPutResponseDto extends EntityDto {
  id?: string;
  name?: string;
  type?: string;
  properties: Properties;
  systemData: SystemData;
}
