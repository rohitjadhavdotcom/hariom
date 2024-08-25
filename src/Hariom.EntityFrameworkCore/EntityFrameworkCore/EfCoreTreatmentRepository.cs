using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Hariom.Treatments;
using Npgsql;

namespace Hariom.EntityFrameworkCore
{
    public class EfCoreTreatmentRepository : EfCoreRepository<HariomDbContext, Treatment, Guid>,
        ITreatmentRepository
    {
        public EfCoreTreatmentRepository(IDbContextProvider<HariomDbContext> dbContextProvider) : base(dbContextProvider)
        {
            
        }

        public async Task<List<TreatmentNavigationModel>> GetByIdAsync(Guid id)
        {
            var context = await GetDbContextAsync();
            var param = new NpgsqlParameter("@Id", id);

            var result = context.Database.SqlQueryRaw<TreatmentNavigationModel>("select t.*,\r\nad.\"Name\" as \"DiseaseName\",\r\nam.\"Id\" as \"MedicineId\",\r\nam.\"Name\" as \"MedicineName\",\r\nam2.\"Id\" as \"MantrasId\",\r\nam2.\"Name\" as \"MantrasName\",\r\nayt.\"Id\" as \"YogTherapyId\",\r\nayt.\"YogopcharTherapy\" as \"YogopcharTherapy\"\r\nfrom public.\"AppTreatments\" t\r\nleft join public.\"AppDiseases\" ad on ad.\"Id\" = t.\"DiseaseId\"\r\nleft join public.\"AppTreatmentMedicineMaps\" tmm on tmm.\"TreatmentId\" = t.\"Id\"\r\nleft join public.\"AppMedicines\" am on am.\"Id\" = tmm.\"MedicineId\"\r\nleft join public.\"AppTreatmentMantraMaps\" tmd on tmd.\"TreatmentId\" = t.\"Id\"\r\nleft join public.\"AppMantras\" am2 on am2.\"Id\" = tmd.\"MantraId\"\r\nleft join public.\"AppTreatmentYogTherapyMaps\" tytm on tytm.\"TreatmentId\" = t.\"Id\"\r\nleft join public.\"AppYogTherapies\" ayt on ayt.\"Id\" = tytm.\"YogTherapyId\"\r\nwhere t.\"Id\" = @Id", param).ToList();
            return result;
        }

        public async Task<List<Treatment>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
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
