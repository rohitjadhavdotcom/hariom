using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hariom.Medicines
{
    public interface IMedicineRepository : IRepository<Medicine, Guid>
    {
        Task<Medicine?> FindByNameAsync(string name);

        Task<List<Medicine>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
