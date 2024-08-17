using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Hariom.Web;

[Dependency(ReplaceServices = true)]
public class HariomBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Hariom";
}
