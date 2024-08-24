using Hariom.Medicines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hariom.Treatments
{
    public interface ITreatmentRepository : IRepository<Treatment, Guid>
    {
        Task<List<Treatment>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
