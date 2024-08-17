using Hariom.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hariom.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class HariomController : AbpControllerBase
{
    protected HariomController()
    {
        LocalizationResource = typeof(HariomResource);
    }
}
