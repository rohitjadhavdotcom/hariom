using Volo.Abp.Modularity;

namespace Hariom;

/* Inherit from this class for your domain layer tests. */
public abstract class HariomDomainTestBase<TStartupModule> : HariomTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
