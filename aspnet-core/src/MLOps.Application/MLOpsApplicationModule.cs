using Microsoft.Extensions.DependencyInjection;
using MLOps.Azure.Client;
using MLOps.Config;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace MLOps;

[DependsOn(
    typeof(MLOpsDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(MLOpsApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class MLOpsApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<MLOpsApplicationModule>();
        context.Services.AddTransient<IMLOpsClient, MlOpsClient>();
        context.Services.AddTransient<IConfigHandler, ConfigHandler>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<MLOpsApplicationModule>();
        });
    }
}
