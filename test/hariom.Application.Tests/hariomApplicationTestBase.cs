using Volo.Abp.Modularity;

namespace Hariom;

public abstract class HariomApplicationTestBase<TStartupModule> : HariomTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
