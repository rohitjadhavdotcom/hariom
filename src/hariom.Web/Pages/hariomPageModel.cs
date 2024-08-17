using hariom.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace hariom.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class hariomPageModel : AbpPageModel
{
    protected hariomPageModel()
    {
        LocalizationResourceType = typeof(hariomResource);
    }
}
