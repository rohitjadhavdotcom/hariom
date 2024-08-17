using Volo.Abp.Settings;

namespace hariom.Settings;

public class hariomSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(hariomSettings.MySetting1));
    }
}
