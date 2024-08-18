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

        var medicinesPermission = hariomGroup.AddPermission(HariomPermissions.Medicines.Default, L("Permission:Medicines"));
        medicinesPermission.AddChild(HariomPermissions.Medicines.Create, L("Permission:Medicines.Create"));
        medicinesPermission.AddChild(HariomPermissions.Medicines.Edit, L("Permission:Medicines.Edit"));
        medicinesPermission.AddChild(HariomPermissions.Medicines.Delete, L("Permission:Medicines.Delete"));

        var mantrasPermission = hariomGroup.AddPermission(HariomPermissions.Mantras.Default, L("Permission:Mantras"));
        mantrasPermission.AddChild(HariomPermissions.Mantras.Create, L("Permission:Mantras.Create"));
        mantrasPermission.AddChild(HariomPermissions.Mantras.Edit, L("Permission:Mantras.Edit"));
        mantrasPermission.AddChild(HariomPermissions.Mantras.Delete, L("Permission:Mantras.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HariomResource>(name);
    }
}
