using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace hariom.Pages;

public class Index_Tests : hariomWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
