using Volo.Abp.Modularity;

namespace MLOps;

[DependsOn(
    typeof(MLOpsApplicationModule),
    typeof(MLOpsDomainTestModule)
    )]
public class MLOpsApplicationTestModule : AbpModule
{

}
