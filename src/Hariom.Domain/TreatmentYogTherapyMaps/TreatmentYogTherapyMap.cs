using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hariom.TreatmentYogTherapyMaps
{
    public class TreatmentYogTherapyMap : AuditedAggregateRoot<Guid>
    {
        public Guid TreatmentId { get; set; }
        public Guid YogTherapyId { get; set; }

        private TreatmentYogTherapyMap()
        {

        }

        internal TreatmentYogTherapyMap(Guid treatmentId, Guid yogTherapyId)
        {
            TreatmentId = treatmentId;
            YogTherapyId = yogTherapyId;
        }
    }
}
