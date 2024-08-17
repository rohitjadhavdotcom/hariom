using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace hariom.Data;

/* This is used if database provider does't define
 * IhariomDbSchemaMigrator implementation.
 */
public class NullhariomDbSchemaMigrator : IhariomDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
