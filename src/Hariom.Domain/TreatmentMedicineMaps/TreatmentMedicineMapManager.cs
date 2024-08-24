using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Hariom.TreatmentMedicineMaps
{
    public class TreatmentMedicineMapManager : DomainService
    {
        public TreatmentMedicineMap Create(Guid treatmentId, Guid medicineId)
        {
            return new TreatmentMedicineMap(treatmentId, medicineId);
        }
    }
}
