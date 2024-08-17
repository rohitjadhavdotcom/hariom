using System.Threading.Tasks;

namespace hariom.Data;

public interface IhariomDbSchemaMigrator
{
    Task MigrateAsync();
}
