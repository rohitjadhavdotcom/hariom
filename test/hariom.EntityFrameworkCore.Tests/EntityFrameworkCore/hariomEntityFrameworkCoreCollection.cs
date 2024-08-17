using Xunit;

namespace hariom.EntityFrameworkCore;

[CollectionDefinition(hariomTestConsts.CollectionDefinitionName)]
public class hariomEntityFrameworkCoreCollection : ICollectionFixture<hariomEntityFrameworkCoreFixture>
{

}
