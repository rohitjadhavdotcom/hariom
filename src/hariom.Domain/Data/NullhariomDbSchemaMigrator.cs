using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Hariom.Data;

/* This is used if database provider does't define
 * IHariomDbSchemaMigrator implementation.
 */
public class NullHariomDbSchemaMigrator : IHariomDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
