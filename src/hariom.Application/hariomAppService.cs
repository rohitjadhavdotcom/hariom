using System;
using System.Collections.Generic;
using System.Text;
using Hariom.Localization;
using Volo.Abp.Application.Services;

namespace Hariom;

/* Inherit your application services from this class.
 */
public abstract class HariomAppService : ApplicationService
{
    protected HariomAppService()
    {
        LocalizationResource = typeof(HariomResource);
    }
}
