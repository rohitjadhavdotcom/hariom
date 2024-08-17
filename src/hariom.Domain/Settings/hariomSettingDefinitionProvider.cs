using Volo.Abp.Settings;

namespace Hariom.Settings;

public class HariomSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(HariomSettings.MySetting1));
    }
}
