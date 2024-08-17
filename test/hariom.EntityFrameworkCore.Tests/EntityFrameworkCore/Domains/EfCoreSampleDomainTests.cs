using Hariom.Samples;
using Xunit;

namespace Hariom.EntityFrameworkCore.Domains;

[Collection(HariomTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<HariomEntityFrameworkCoreTestModule>
{

}
