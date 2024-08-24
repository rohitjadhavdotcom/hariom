using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Hariom.TreatmentYogTherapyMaps
{
    public class TreatmentYogTherapyMapManager : DomainService
    {
        public TreatmentYogTherapyMap Create(Guid treatmentId, Guid yogTherapyId)
        {
            return new TreatmentYogTherapyMap(treatmentId, yogTherapyId);
        }
    }
}
