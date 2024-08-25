using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hariom.Treatments
{
    public class TreatmentNavigationModel
    {
        public string AboutDisease { get; set; } = null!;
        public string? DiseaseSymptoms { get; set; }
        public string? DiseaseCauses { get; set; }
        public string? DiseaseDiagnose { get; set; }
        public string? MedicineDescription { get; set; }
        public string? MantraDescription { get; set; }
        public string? YogupcharDescription { get; set; }
        public string? OtherRemedies { get; set; }
        public string? ImmediateTreatment { get; set; }
        public string? PathyaAahar { get; set; }
        public string? PathyaVihar { get; set; }
        public string? ApathyaAahar { get; set; }
        public string? ApathyaVihar { get; set; }
        public string? SantsangLink { get; set; }
        public string? SadhakAnubhavLink { get; set; }

        public Guid DiseaseId { get; set; }
        public Guid? MedicineId { get; set; }
        public Guid? MantrasId { get; set; }
        public Guid? YogTherapyId { get; set; }
        public string DiseaseName { get; set; } = null!;
        public string? MedicineName { get; set;}
        public string? MantrasName { get; set; }
        public string? YogopcharTherapy { get; set; }

    }
}
