
export interface AssetDefinitionAsset {
  path?: string;
  type: number;
  assetId?: string;
  serializedAssetId?: string;
}

export interface AssetDefinitionObj {
  literalValue?: string;
  dataSetReference?: string;
  savedDataSetReference?: string;
  assetReference?: string;
  assetDefinition: AssetDefinitionAsset;
}

export interface AssetOutputSettingsAssignments {
}

export interface DefaultCompute {
  name?: string;
  computeType: object;
  batchAiComputeInfo?: string;
  remoteDockerComputeInfo?: string;
  hdiClusterComputeInfo?: string;
  mlcComputeInfo: MlcComputeInfo;
  databricksComputeInfo: object;
}

export interface DefaultDatastore {
  dataStoreName?: string;
}

export interface MlcComputeInfo {
  mlcComputeType?: string;
}

export interface PipelineResponseCreatedBy {
  userObjectId?: string;
  userTenantId?: string;
  userName?: string;
}

export interface PipelineResponseStatus {
  statusCode: number;
  statusDetail?: string;
  creationTime?: string;
  endTime?: string;
}
