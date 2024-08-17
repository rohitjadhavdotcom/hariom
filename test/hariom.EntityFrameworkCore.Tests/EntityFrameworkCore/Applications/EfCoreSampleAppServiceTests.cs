using hariom.Samples;
using Xunit;

namespace hariom.EntityFrameworkCore.Applications;

[Collection(hariomTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<hariomEntityFrameworkCoreTestModule>
{

}
