using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Hariom.Treatments;
using Hariom.TreatmentYogTherapyMaps;

namespace Hariom.EntityFrameworkCore
{
    public class EfCoreTreatmentYogTherapyMapRepository : EfCoreRepository<HariomDbContext, TreatmentYogTherapyMap, Guid>,
        ITreatmentYogTherapyMapRepository
    { 
        public EfCoreTreatmentYogTherapyMapRepository(IDbContextProvider<HariomDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<TreatmentYogTherapyMap>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
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
