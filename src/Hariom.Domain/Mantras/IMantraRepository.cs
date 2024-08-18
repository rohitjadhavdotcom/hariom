using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hariom.Mantras
{
    public interface IMantraRepository : IRepository<Mantra, Guid>
    {
        Task<Mantra?> FindByNameAsync(string name);

        Task<List<Mantra>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
