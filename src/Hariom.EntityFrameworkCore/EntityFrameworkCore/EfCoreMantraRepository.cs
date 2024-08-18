using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Hariom.Mantras;
using Hariom.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hariom.EntityFrameworkCore
{
    public class EfCoreMantraRepository :
         EfCoreRepository<HariomDbContext, Mantra, Guid>,
        IMantraRepository
    {
        public EfCoreMantraRepository(IDbContextProvider<HariomDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Mantra?> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(mantra => mantra.Name == name);
        }

        public async Task<List<Mantra>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    mantra => mantra.Name.Contains(filter)
                    )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
