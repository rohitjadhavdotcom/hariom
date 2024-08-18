using Hariom.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hariom.Permissions;

public class HariomPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var hariomGroup = context.AddGroup(HariomPermissions.GroupName, L("Permission:Hariom"));

        var diseasesPermission = hariomGroup.AddPermission(HariomPermissions.Diseases.Default, L("Permission:Diseases"));
        diseasesPermission.AddChild(HariomPermissions.Diseases.Create, L("Permission:Diseases.Create"));
        diseasesPermission.AddChild(HariomPermissions.Diseases.Edit, L("Permission:Diseases.Edit"));
        diseasesPermission.AddChild(HariomPermissions.Diseases.Delete, L("Permission:Diseases.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HariomResource>(name);
    }
}
