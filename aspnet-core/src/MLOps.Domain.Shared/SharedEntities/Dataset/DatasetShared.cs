using System;
using System.Collections.Generic;

namespace MLOps.SharedEntities.Dataset;

public class SystemData
{
    public virtual string CreatedAt { get; set; }
    public virtual string CreatedBy { get; set; }
    public virtual string CreatedByType { get; set; }
    public virtual string LastModifiedAt { get; set; }
    public virtual string LastModifiedBy { get; set; }
    public virtual string LastModifiedByType { get; set; }
}

public class Properties : PropertiesDetail
{
    public string DataUri { get; set; }
}


public class PropertiesDetail
{
    public string DataType { get; set; }
    public string Description { get; set; }
}

public class WorkspaceData
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public PropertiesGet Properties { get; set; }
    public SystemDataGet SystemData { get; set; }
}

public class PropertiesGet
{
    public string Description { get; set; }
    public Dictionary<string, string> Tags { get; set; }
    public object PropertiesObj { get; set; }
    public bool IsArchived { get; set; }
    public string LatestVersion { get; set; }
    public string NextVersion { get; set; }
    public string DataType { get; set; }
}

public class SystemDataGet
{
    public DateTime CreatedAt { get; set; }
    public DateTime LastModifiedAt { get; set; }
}

public class ValueGetVersions
{
    public string id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public PropertiesGetVersions properties { get; set; }
    public SystemData systemData { get; set; }
}

public class PropertiesGetVersions
{
    public string DataType { get; set; }
    public string DataUri { get; set; }
    public string Description { get; set; }
    public Dictionary<string, string> Tags { get; set; }
    public Dictionary<string, string> Properties { get; set; }
    public bool IsAnonymous { get; set; }
}