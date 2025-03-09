using Volo.Abp.Settings;

namespace MLOps.Settings;

public class MLOpsSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MLOpsSettings.MySetting1));
    }
}
