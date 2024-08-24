using Hariom.Treatments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hariom.TreatmentYogTherapyMaps
{
    public interface ITreatmentYogTherapyMapRepository : IRepository<TreatmentYogTherapyMap, Guid>
    {
    }
}
