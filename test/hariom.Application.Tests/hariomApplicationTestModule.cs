using Volo.Abp.Modularity;

namespace Hariom;

[DependsOn(
    typeof(HariomApplicationModule),
    typeof(HariomDomainTestModule)
)]
public class HariomApplicationTestModule : AbpModule
{

}
