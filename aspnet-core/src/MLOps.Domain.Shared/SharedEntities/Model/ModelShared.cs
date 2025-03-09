using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MLOps.SharedEntities.Model;

public class Version
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public Properties Properties { get; set; }
    public SystemData SystemData { get; set; }
}

public class Properties
{
    public object Description { get; set; }
    public Dictionary<string, object> Tags { get; set; }
    [JsonPropertyName("Properties")]
    public PythonProperties PythonProperties { get; set; }
    public bool IsArchived { get; set; }
    public bool IsAnonymous { get; set; }
    public Flavors Flavors { get; set; }
    public string ModelType { get; set; }
    public string ModelUri { get; set; }
    public string JobName { get; set; }
}

public class PythonProperties
{
    [JsonPropertyName("flavors.python_function")]
    public string FlavorsPythonFunction { get; set; }

    [JsonPropertyName("flavors.sklearn")]
    public string FlavorsSklearn { get; set; }

    public string Flavors { get; set; }

    [JsonPropertyName("azureml.artifactPrefix")]
    public string AzuremlArtifactPrefix { get; set; }

    [JsonPropertyName("model_json")]
    public string ModelJson { get; set; }

    [JsonPropertyName("azureml.storagePath")]
    public string AzuremlStoragePath { get; set; }

    [JsonPropertyName("mlflow.modelSourceUri")]
    public string MlflowModelSourceUri { get; set; }
}

public class Flavors
{
    [JsonPropertyName("python_function")]
    public PythonFunction PythonFunction { get; set; }

    public Sklearn Sklearn { get; set; }
}

public class PythonFunction
{
    public Data data { get; set; }
}

public class Sklearn
{
    public Data Data { get; set; }
}

public class Data
{
    [JsonPropertyName("model_path")]
    public string ModelPath { get; set; }

    [JsonPropertyName("predict_fn")]
    public string PredictFn { get; set; }

    [JsonPropertyName("loader_module")]
    public string LoaderModule { get; set; }

    [JsonPropertyName("python_version")]
    public string PythonVersion { get; set; }

    public string Env { get; set; }

    [JsonPropertyName("pickled_model")]
    public string PickledModel { get; set; }

    [JsonPropertyName("sklearn_version")]
    public string SklearnVersion { get; set; }

    [JsonPropertyName("serialization_format")]
    public string SerializationFormat { get; set; }

    public string Code { get; set; }
}

public class SystemData
{
    public string CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string CreatedByType { get; set; }
    public string LastModifiedAt { get; set; }
    public string LastModifiedBy { get; set; }
    public string LastModifiedByType { get; set; }
}
