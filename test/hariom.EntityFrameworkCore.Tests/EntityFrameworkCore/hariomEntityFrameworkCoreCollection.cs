using Xunit;

namespace Hariom.EntityFrameworkCore;

[CollectionDefinition(HariomTestConsts.CollectionDefinitionName)]
public class HariomEntityFrameworkCoreCollection : ICollectionFixture<HariomEntityFrameworkCoreFixture>
{

}
