using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MLOps.Data;

/* This is used if database provider does't define
 * IMLOpsDbSchemaMigrator implementation.
 */
public class NullMLOpsDbSchemaMigrator : IMLOpsDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
