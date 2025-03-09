using Localization.Resources.AbpUi;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using MLOps.Localization;

namespace MLOps;

[DependsOn(
    typeof(MLOpsApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class MLOpsHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(MLOpsHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<MLOpsResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
