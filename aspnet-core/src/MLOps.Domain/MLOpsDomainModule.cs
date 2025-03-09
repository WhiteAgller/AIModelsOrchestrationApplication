using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace MLOps;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(MLOpsDomainSharedModule)
)]
public class MLOpsDomainModule : AbpModule
{

}
