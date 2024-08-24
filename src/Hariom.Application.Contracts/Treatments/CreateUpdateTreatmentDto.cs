using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hariom.Treatments
{
    public class CreateUpdateTreatmentDto
    {
        [StringLength(1000)]
        public string AboutDisease { get; set; } = null!;
        [StringLength(1000)]
        public string? DiseaseSymptoms { get; set; }
        [StringLength(1000)]
        public string? DiseaseCauses { get; set; }
        [StringLength(1000)]
        public string? DiseaseDiagnose { get; set; }
        [StringLength(1000)]
        public string? MedicineDescription { get; set; }
        [StringLength(1000)]
        public string? MantraDescription { get; set; }
        [StringLength(1000)]
        public string? YogupcharDescription { get; set; }
        [StringLength(1000)]
        public string? OtherRemedies { get; set; }
        [StringLength(1000)]
        public string? ImmediateTreatment { get; set; }

        [StringLength(1000)]
        public string? PathyaAahar { get; set; }
        [StringLength(1000)]
        public string? PathyaVihar { get; set; }
        [StringLength(1000)]
        public string? ApathyaAahar { get; set; }
        [StringLength(1000)]
        public string? ApathyaVihar { get; set; }

        [StringLength(1000)]
        public string? SantsangLink { get; set; }
        [StringLength(1000)]
        public string? SadhakAnubhavLink { get; set; }

        public List<Guid> SelectedDiseases { get; set; } = [];
        public List<Guid>? SelectedMantras { get; set; }
        public List<Guid> SelectedMedicines { get; set; } = [];
        public List<Guid>? SelectedYogtheropies { get; set; }
    }
}
