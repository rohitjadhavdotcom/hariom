using Hariom.Samples;
using Xunit;

namespace Hariom.EntityFrameworkCore.Applications;

[Collection(HariomTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<HariomEntityFrameworkCoreTestModule>
{

}
