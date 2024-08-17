using hariom.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace hariom.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(hariomEntityFrameworkCoreModule),
    typeof(hariomApplicationContractsModule)
    )]
public class hariomDbMigratorModule : AbpModule
{
}
