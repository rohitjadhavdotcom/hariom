using Hariom.Diseases;
using Hariom.Mantras;
using Hariom.Medicines;
using Hariom.YogTherapies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hariom.Treatments
{
    public class TreatmentNavigationModelDto
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
        public string DiseaseName { get; set; } = null!;

        public List<MedicineDto> Medicines { get; set; } = [];
        //public List<DiseaseDto> Diseases { get; set; } = [];
        public List<YogTherapyDto> YogTherapies { get; set; } = [];
        public List<MantraDto> Mantras { get; set; } = [];
    }
}
