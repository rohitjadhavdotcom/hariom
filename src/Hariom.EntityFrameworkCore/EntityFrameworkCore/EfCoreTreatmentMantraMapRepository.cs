using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Hariom.Treatments;
using Hariom.TreatmentMantraMaps;

namespace Hariom.EntityFrameworkCore
{
    public class EfCoreTreatmentMantraMapRepository : EfCoreRepository<HariomDbContext, TreatmentMantraMap, Guid>,
        ITreatmentMantraMapRepository
    {
        public EfCoreTreatmentMantraMapRepository(IDbContextProvider<HariomDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<TreatmentMantraMap>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
