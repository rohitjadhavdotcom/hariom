using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hariom.Diseases
{
    public interface IDiseaseRepository : IRepository<Disease, Guid>
    {
        Task<Disease?> FindByNameAsync(string name);

        Task<List<Disease>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
