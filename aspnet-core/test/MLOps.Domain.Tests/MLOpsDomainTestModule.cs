using MLOps.MongoDB;
using Volo.Abp.Modularity;

namespace MLOps;

[DependsOn(
    typeof(MLOpsMongoDbTestModule)
    )]
public class MLOpsDomainTestModule : AbpModule
{

}
