using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Hariom.Web;

[Dependency(ReplaceServices = true)]
public class HariomBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Hariom";
    public override string LogoUrl => "/images/logo/pngwing.com.png";
    public override string LogoReverseUrl => "/images/logo/pngwing.com.png";
}
