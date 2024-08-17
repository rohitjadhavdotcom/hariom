using hariom.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace hariom.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class hariomController : AbpControllerBase
{
    protected hariomController()
    {
        LocalizationResource = typeof(hariomResource);
    }
}
