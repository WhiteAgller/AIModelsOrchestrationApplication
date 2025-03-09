
export interface Properties extends PropertiesDetail {
  dataUri?: string;
}

export interface PropertiesDetail {
  dataType?: string;
  description?: string;
}

export interface PropertiesGet {
  description?: string;
  tags: Record<string, string>;
  propertiesObj: object;
  isArchived: boolean;
  latestVersion?: string;
  nextVersion?: string;
  dataType?: string;
}

export interface SystemData {
  createdAt?: string;
  createdBy?: string;
  createdByType?: string;
  lastModifiedAt?: string;
  lastModifiedBy?: string;
  lastModifiedByType?: string;
}

export interface SystemDataGet {
  createdAt?: string;
  lastModifiedAt?: string;
}

export interface WorkspaceData {
  id?: string;
  name?: string;
  type?: string;
  properties: PropertiesGet;
  systemData: SystemDataGet;
}
