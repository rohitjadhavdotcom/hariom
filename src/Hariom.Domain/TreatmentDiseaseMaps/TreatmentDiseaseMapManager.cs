using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Hariom.TreatmentDiseaseMaps
{
    public class TreatmentDiseaseMapManager : DomainService
    {
        public TreatmentDiseaseMap Create(Guid treatmentId, Guid diseaseId)
        {
            return new TreatmentDiseaseMap(treatmentId, diseaseId);
        }
    }
}
