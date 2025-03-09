
export interface Data {
  model_path?: string;
  predict_fn?: string;
  loader_module?: string;
  python_version?: string;
  env?: string;
  pickled_model?: string;
  sklearn_version?: string;
  serialization_format?: string;
  code?: string;
}

export interface Flavors {
  python_function: PythonFunction;
  sklearn: Sklearn;
}

export interface Properties {
  description: object;
  tags: Record<string, object>;
  Properties: PythonProperties;
  isArchived: boolean;
  isAnonymous: boolean;
  flavors: Flavors;
  modelType?: string;
  modelUri?: string;
  jobName?: string;
}

export interface PythonFunction {
  data: Data;
}

export interface PythonProperties {
  'flavors.python_function'?: string;
  'flavors.sklearn'?: string;
  flavors?: string;
  'azureml.artifactPrefix'?: string;
  model_json?: string;
  'azureml.storagePath'?: string;
  'mlflow.modelSourceUri'?: string;
}

export interface Sklearn {
  data: Data;
}

export interface SystemData {
  createdAt?: string;
  createdBy?: string;
  createdByType?: string;
  lastModifiedAt?: string;
  lastModifiedBy?: string;
  lastModifiedByType?: string;
}

export interface Version {
  id?: string;
  name?: string;
  type?: string;
  properties: Properties;
  systemData: SystemData;
}
