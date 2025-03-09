using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace MLOps.MongoDB;

[DependsOn(
    typeof(MLOpsTestBaseModule),
    typeof(MLOpsMongoDbModule)
    )]
public class MLOpsMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var stringArray = MLOpsMongoDbFixture.ConnectionString.Split('?');
        var connectionString = stringArray[0].EnsureEndsWith('/') +
                                   "Db_" +
                               Guid.NewGuid().ToString("N") + "/?" + stringArray[1];

        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = connectionString;
        });
    }
}
