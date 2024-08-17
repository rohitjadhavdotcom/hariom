using Microsoft.AspNetCore.Builder;
using Hariom;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<HariomWebTestModule>();

public partial class Program
{
}
