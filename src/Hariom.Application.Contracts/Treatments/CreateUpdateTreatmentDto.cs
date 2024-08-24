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
        public string DiseaseSymptoms { get; set; } = null!;
        [StringLength(1000)]
        public string DiseaseCauses { get; set; } = null!;
        [StringLength(1000)]
        public string DiseaseDiagnose { get; set; } = null!;
        [StringLength(1000)]
        public string MedicineDescription { get; set; } = null!;
        [StringLength(1000)]
        public string MantraDescription { get; set; } = null!;
        [StringLength(1000)]
        public string YogupcharDescription { get; set; } = null!;
        [StringLength(1000)]
        public string OtherRemedies { get; set; } = null!;
        [StringLength(1000)]
        public string ImmediateTreatment { get; set; } = null!;

        [StringLength(1000)]
        public string PathyaAahar { get; set; } = null!;
        [StringLength(1000)]
        public string PathyaVihar { get; set; } = null!;
        [StringLength(1000)]
        public string ApathyaAahar { get; set; } = null!;
        [StringLength(1000)]
        public string ApathyaVihar { get; set; } = null!;

        [StringLength(1000)]
        public string SantsangLink { get; set; } = null!;
        [StringLength(1000)]
        public string SadhakAnubhavLink { get; set; } = null!;
    }
}
