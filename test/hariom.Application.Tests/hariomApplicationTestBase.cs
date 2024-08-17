using Volo.Abp.Modularity;

namespace hariom;

public abstract class hariomApplicationTestBase<TStartupModule> : hariomTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
