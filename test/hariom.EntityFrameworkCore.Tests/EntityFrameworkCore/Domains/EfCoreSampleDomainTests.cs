using hariom.Samples;
using Xunit;

namespace hariom.EntityFrameworkCore.Domains;

[Collection(hariomTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<hariomEntityFrameworkCoreTestModule>
{

}
