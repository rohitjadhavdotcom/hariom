using Hariom.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Hariom.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(HariomEntityFrameworkCoreModule),
    typeof(HariomApplicationContractsModule)
    )]
public class HariomDbMigratorModule : AbpModule
{
}
