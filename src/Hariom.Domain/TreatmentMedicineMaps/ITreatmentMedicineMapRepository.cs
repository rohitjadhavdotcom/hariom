using Hariom.Treatments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hariom.TreatmentMedicineMaps
{
    public interface ITreatmentMedicineMapRepository : IRepository<TreatmentMedicineMap, Guid>
    {
    }
}
