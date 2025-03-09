using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.VirtualFileSystem;

namespace MLOps;

[DependsOn(
    typeof(MLOpsApplicationContractsModule),
    typeof(AbpAccountHttpApiClientModule),
    typeof(AbpIdentityHttpApiClientModule),
    typeof(AbpPermissionManagementHttpApiClientModule),
    typeof(AbpTenantManagementHttpApiClientModule),
    typeof(AbpFeatureManagementHttpApiClientModule),
    typeof(AbpSettingManagementHttpApiClientModule)
)]
public class MLOpsHttpApiClientModule : AbpModule
{

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(MLOpsApplicationContractsModule).Assembly,
            MLOpsRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<MLOpsHttpApiClientModule>();
        });
    }
}
