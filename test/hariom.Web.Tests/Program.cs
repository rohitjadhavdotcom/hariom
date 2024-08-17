using Microsoft.AspNetCore.Builder;
using hariom;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<hariomWebTestModule>();

public partial class Program
{
}
