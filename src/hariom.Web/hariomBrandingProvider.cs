using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace hariom.Web;

[Dependency(ReplaceServices = true)]
public class hariomBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "hariom";
}
