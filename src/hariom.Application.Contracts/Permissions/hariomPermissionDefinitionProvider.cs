using Hariom.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hariom.Permissions;

public class HariomPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(HariomPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(HariomPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HariomResource>(name);
    }
}
