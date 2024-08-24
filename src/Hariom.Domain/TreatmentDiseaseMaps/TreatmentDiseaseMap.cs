using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hariom.TreatmentDiseaseMaps
{
    public class TreatmentDiseaseMap : AuditedAggregateRoot<Guid>
    {
        public Guid TreatmentId { get; set; }
        public Guid DiseaseId { get; set; }

        private TreatmentDiseaseMap()
        {

        }

        internal TreatmentDiseaseMap(Guid treatmentId, Guid diseaseId)
        {
            TreatmentId = treatmentId;
            DiseaseId = diseaseId;
        }
    }
}
