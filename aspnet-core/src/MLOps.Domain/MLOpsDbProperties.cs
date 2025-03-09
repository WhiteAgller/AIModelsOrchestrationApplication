namespace MLOps;

public static class MLOpsDbProperties
{
    public static string DbTablePrefix { get; set; } = "MLOps";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "MLOps";
}
