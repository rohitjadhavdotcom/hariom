using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hariom.Treatments
{
    public class CreateUpdateTreatmentDto
    {
        [StringLength(1000)]
        [DisplayName("About Disease")]
        public string AboutDisease { get; set; } = null!;
        [StringLength(1000)]
        [DisplayName("Disease Symptoms")]
        public string? DiseaseSymptoms { get; set; }
        [StringLength(1000)]
        [DisplayName("Disease Causes")]
        public string? DiseaseCauses { get; set; }
        [StringLength(1000)]
        [DisplayName("Disease Diagnose")]
        public string? DiseaseDiagnose { get; set; }
        [StringLength(1000)]
        [DisplayName("Medicine Description")]
        public string? MedicineDescription { get; set; }
        [StringLength(1000)]
        [DisplayName("Mantra Description")]
        public string? MantraDescription { get; set; }
        [StringLength(1000)]
        [DisplayName("Yogupchar Description")]
        public string? YogupcharDescription { get; set; }
        [StringLength(1000)]
        [DisplayName("Other Remedies")]
        public string? OtherRemedies { get; set; }
        [StringLength(1000)]
        [DisplayName("Immediate Treatment")]
        public string? ImmediateTreatment { get; set; }

        [StringLength(1000)]
        [DisplayName("Pathya Aahar")]
        public string? PathyaAahar { get; set; }
        [StringLength(1000)]
        [DisplayName("Pathya Vihar")]
        public string? PathyaVihar { get; set; }
        [StringLength(1000)]
        [DisplayName("Apathya Aahar")]
        public string? ApathyaAahar { get; set; }
        [StringLength(1000)]
        [DisplayName("Apathya Vihar")]
        public string? ApathyaVihar { get; set; }

        [StringLength(1000)]
        [DisplayName("Santsang Link")]
        public string? SantsangLink { get; set; }
        [StringLength(1000)]
        [DisplayName("Sadhak Anubhav Link")]
        public string? SadhakAnubhavLink { get; set; }

        [DisplayName("Diasese")]
        public Guid DiseaseId { get; set; }

        //[DisplayName("Diasese")]
        //public List<Guid> SelectedDiseases { get; set; } = [];
        [DisplayName("Mantras")]
        public List<Guid>? SelectedMantras { get; set; }
        [DisplayName("Medicines")]
        public List<Guid> SelectedMedicines { get; set; } = [];
        [DisplayName("Yogtheropies")]
        public List<Guid>? SelectedYogtheropies { get; set; }
    }
}
