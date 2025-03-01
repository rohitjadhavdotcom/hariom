using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Hariom.Treatments
{
    public class CreateUpdateTreatmentDto
    {
        [StringLength(1000)]
        [DisplayName("About Disease")]
        [TextArea()]
        public string? AboutDisease { get; set; } = null!;

        [StringLength(1000)]
        [DisplayName("Disease Symptoms")]
        [TextArea()]
        public string? DiseaseSymptoms { get; set; }

        [StringLength(1000)]
        [DisplayName("Disease Causes")]
        [TextArea()]
        public string? DiseaseCauses { get; set; }

        [StringLength(1000)]
        [DisplayName("Disease Diagnose")]
        [TextArea()]
        public string? DiseaseDiagnose { get; set; }

        [StringLength(1000)]
        [DisplayName("Medicine Description")]
        [TextArea()]
        public string? MedicineDescription { get; set; }

        [StringLength(1000)]
        [DisplayName("Mantra Description")]
        [TextArea()]
        public string? MantraDescription { get; set; }

        [StringLength(1000)]
        [DisplayName("Yogupchar Description")]
        [TextArea()]
        public string? YogupcharDescription { get; set; }

        [StringLength(1000)]
        [DisplayName("Other Remedies")]
        public string? OtherRemedies { get; set; }

        [StringLength(1000)]
        [DisplayName("Immediate Treatment")]
        [TextArea()]
        public string? ImmediateTreatment { get; set; }

        [StringLength(1000)]
        [DisplayName("Pathya Aahar")]
        [TextArea()]
        public string? PathyaAahar { get; set; }

        [StringLength(1000)]
        [DisplayName("Pathya Vihar")]
        public string? PathyaVihar { get; set; }

        [StringLength(1000)]
        [DisplayName("Apathya Aahar")]
        [TextArea()]
        public string? ApathyaAahar { get; set; }

        [StringLength(1000)]
        [DisplayName("Apathya Vihar")]
        [TextArea()]
        public string? ApathyaVihar { get; set; }

        [StringLength(1000)]
        [DisplayName("Santsang Link")]
        public string? SantsangLink { get; set; }

        [StringLength(1000)]
        [DisplayName("Sadhak Anubhav Link")]
        public string? SadhakAnubhavLink { get; set; }

        [DisplayName("Diasese")]
        [Required]
        public Guid DiseaseId { get; set; }

        //[DisplayName("Diasese")]
        //public List<Guid> SelectedDiseases { get; set; } = [];
        [DisplayName("Mantras")]
        public List<Guid>? SelectedMantras { get; set; }

        [DisplayName("Medicines")]
        public List<Guid>? SelectedMedicines { get; set; } = [];

        [DisplayName("Yogtheropies")]
        public List<Guid>? SelectedYogtheropies { get; set; }
    }
}
