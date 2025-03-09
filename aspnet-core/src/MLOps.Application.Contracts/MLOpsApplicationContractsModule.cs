using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace MLOps;

[DependsOn(
    typeof(MLOpsDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class MLOpsApplicationContractsModule : AbpModule
{

}
