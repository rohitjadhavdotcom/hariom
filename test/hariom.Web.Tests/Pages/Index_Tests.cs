using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Hariom.Pages;

public class Index_Tests : HariomWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
