using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hariom.TreatmentMedicineMaps
{
    public class TreatmentMedicineMap : AuditedAggregateRoot<Guid>
    {
        public Guid TreatmentId { get; set; }
        public Guid MedicineId { get; set; }

        private TreatmentMedicineMap()
        {

        }

        internal TreatmentMedicineMap(Guid treatmentId, Guid medicineId)
        {
            TreatmentId = treatmentId;
            MedicineId = medicineId;
        }
    }
}
