using System;
using System.Collections.Generic;
using System.Text;
using hariom.Localization;
using Volo.Abp.Application.Services;

namespace hariom;

/* Inherit your application services from this class.
 */
public abstract class hariomAppService : ApplicationService
{
    protected hariomAppService()
    {
        LocalizationResource = typeof(hariomResource);
    }
}
