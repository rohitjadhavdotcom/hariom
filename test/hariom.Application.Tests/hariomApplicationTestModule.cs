using Volo.Abp.Modularity;

namespace hariom;

[DependsOn(
    typeof(hariomApplicationModule),
    typeof(hariomDomainTestModule)
)]
public class hariomApplicationTestModule : AbpModule
{

}
