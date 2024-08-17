using Volo.Abp.Modularity;

namespace hariom;

/* Inherit from this class for your domain layer tests. */
public abstract class hariomDomainTestBase<TStartupModule> : hariomTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
