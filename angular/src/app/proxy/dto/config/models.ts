import type { EntityDto } from '@abp/ng.core';

export interface ConfigDto extends EntityDto {
  id?: string;
  subscription?: string;
  resourceGroup?: string;
  workspace?: string;
  workspaceId?: string;
  tenantId?: string;
  storageKey?: string;
  logBlobContainerName?: string;
  dataBlobContainerName?: string;
  logFolderPath?: string;
  dataFolderPath?: string;
  clientId?: string;
  clientSecret?: string;
  userId?: string;
}
