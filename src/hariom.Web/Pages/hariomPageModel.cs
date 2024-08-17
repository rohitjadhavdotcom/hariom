using Hariom.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hariom.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class HariomPageModel : AbpPageModel
{
    protected HariomPageModel()
    {
        LocalizationResourceType = typeof(HariomResource);
    }
}
