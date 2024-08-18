using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hariom.YogTherapies
{
    public interface IYogTherapyRepository : IRepository<YogTherapy, Guid>
    {
        Task<YogTherapy?> FindByYogopcharCategoryAsync(string yogopcharCategory);

        Task<List<YogTherapy>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
