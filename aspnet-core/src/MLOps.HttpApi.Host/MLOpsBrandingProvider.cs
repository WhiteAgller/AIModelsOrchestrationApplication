using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace MLOps;

[Dependency(ReplaceServices = true)]
public class MLOpsBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "MLOps";
}
