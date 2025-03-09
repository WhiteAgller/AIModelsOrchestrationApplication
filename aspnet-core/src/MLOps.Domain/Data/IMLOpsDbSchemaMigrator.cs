using System.Threading.Tasks;

namespace MLOps.Data;

public interface IMLOpsDbSchemaMigrator
{
    Task MigrateAsync();
}
