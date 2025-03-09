using MLOps.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace MLOps.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MLOpsMongoDbModule),
    typeof(MLOpsApplicationContractsModule)
    )]
public class MLOpsDbMigratorModule : AbpModule
{

}
