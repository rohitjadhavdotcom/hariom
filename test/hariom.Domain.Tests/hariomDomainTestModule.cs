using Volo.Abp.Modularity;

namespace Hariom;

[DependsOn(
    typeof(HariomDomainModule),
    typeof(HariomTestBaseModule)
)]
public class HariomDomainTestModule : AbpModule
{

}
