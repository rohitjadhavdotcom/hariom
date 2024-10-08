﻿using Hariom.Localization;
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

        var yogTherapiesPermission = hariomGroup.AddPermission(HariomPermissions.YogTherapies.Default, L("Permission:YogTherapies"));
        yogTherapiesPermission.AddChild(HariomPermissions.YogTherapies.Create, L("Permission:YogTherapies.Create"));
        yogTherapiesPermission.AddChild(HariomPermissions.YogTherapies.Edit, L("Permission:YogTherapies.Edit"));
        yogTherapiesPermission.AddChild(HariomPermissions.YogTherapies.Delete, L("Permission:YogTherapies.Delete"));

        var treatmentsPermission = hariomGroup.AddPermission(HariomPermissions.Treatments.Default, L("Permission:Treatments"));
        treatmentsPermission.AddChild(HariomPermissions.Treatments.Create, L("Permission:Treatments.Create"));
        treatmentsPermission.AddChild(HariomPermissions.Treatments.Edit, L("Permission:Treatments.Edit"));
        treatmentsPermission.AddChild(HariomPermissions.Treatments.Delete, L("Permission:Treatments.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HariomResource>(name);
    }
}
