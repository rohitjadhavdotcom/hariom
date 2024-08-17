using Volo.Abp.Modularity;

namespace hariom;

[DependsOn(
    typeof(hariomDomainModule),
    typeof(hariomTestBaseModule)
)]
public class hariomDomainTestModule : AbpModule
{

}
