using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Hariom.TreatmentMantraMaps
{
    public class TreatmentMantraMapManager : DomainService
    {
        public TreatmentMantraMap Create(Guid treatmentId, Guid mantraId)
        {
            return new TreatmentMantraMap(treatmentId, mantraId);
        }
    }
}
