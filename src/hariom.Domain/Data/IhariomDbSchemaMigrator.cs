using System.Threading.Tasks;

namespace Hariom.Data;

public interface IHariomDbSchemaMigrator
{
    Task MigrateAsync();
}
