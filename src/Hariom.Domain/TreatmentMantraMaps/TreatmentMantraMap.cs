using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hariom.TreatmentMantraMaps
{
    public class TreatmentMantraMap : AuditedAggregateRoot<Guid>
    {
        public Guid TreatmentId { get; set; }
        public Guid MantraId { get; set; }
        private TreatmentMantraMap()
        {

        }
        internal TreatmentMantraMap(Guid treatmentId, Guid mantraId)
        {
            TreatmentId = treatmentId;
            MantraId = mantraId;
        }
    }
}
