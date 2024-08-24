using System.Threading.Tasks;
using Hariom.Localization;
using Hariom.MultiTenancy;
using Hariom.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Hariom.Web.Menus;

public class HariomMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<HariomResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                HariomMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        context.Menu.AddItem(
                new ApplicationMenuItem(
                    "DiseaseStore.Diseases",
                    l["Menu:Diseases"],
                    url: "/Diseases",
                    icon: "fa fa-book"
                ).RequirePermissions(HariomPermissions.Diseases.Default)
        );

        context.Menu.AddItem(
                new ApplicationMenuItem(
                    "DiseaseStore.Medicines",
                    l["Menu:Medicines"],
                    url: "/Medicines",
                    icon: "fa fa-book"
                ).RequirePermissions(HariomPermissions.Medicines.Default)
        );

        context.Menu.AddItem(
                new ApplicationMenuItem(
                    "MantraStore.Mantras",
                    l["Menu:Mantras"],
                    url: "/Mantras",
                    icon: "fa fa-book"
                ).RequirePermissions(HariomPermissions.Mantras.Default)
        );

        context.Menu.AddItem(
                new ApplicationMenuItem(
                    "MantraStore.YogTherapies",
                    l["Menu:YogTherapies"],
                    url: "/YogTherapies",
                    icon: "fa fa-book"
                ).RequirePermissions(HariomPermissions.Mantras.Default)
        );

        context.Menu.AddItem(
                new ApplicationMenuItem(
                    "TreatmentStore.Treatments",
                    l["Menu:Treatments"],
                    url: "/Treatments",
                    icon: "fa fa-book"
                ).RequirePermissions(HariomPermissions.Treatments.Default)
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        return Task.CompletedTask;
    }
}
