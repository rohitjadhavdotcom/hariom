using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Hariom.YogTherapies;
using Hariom.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hariom.EntityFrameworkCore
{
    public class EfCoreYogTherapyRepository :
         EfCoreRepository<HariomDbContext, YogTherapy, Guid>,
        IYogTherapyRepository
    {
        public EfCoreYogTherapyRepository(IDbContextProvider<HariomDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<YogTherapy?> FindByYogopcharCategoryAsync(string yogopcharCategory)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(yogTherapy => yogTherapy.YogopcharCategory == yogopcharCategory);
        }

        public async Task<List<YogTherapy>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    yogTherapy => yogTherapy.YogopcharCategory.Contains(filter)
                    )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
