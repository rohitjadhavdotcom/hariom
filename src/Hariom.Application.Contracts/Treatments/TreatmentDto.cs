using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Hariom.Treatments
{
    public class TreatmentDto : AuditedEntityDto<Guid>
    {
        public string AboutDisease { get; set; } = null!;
        public string DiseaseSymptoms { get; set; } = null!;
        public string DiseaseCauses { get; set; } = null!;
        public string DiseaseDiagnose { get; set; } = null!;
        public string MedicineDescription { get; set; } = null!;
        public string MantraDescription { get; set; } = null!;
        public string YogupcharDescription { get; set; } = null!;
        public string OtherRemedies { get; set; } = null!;
        public string ImmediateTreatment { get; set; } = null!;
        public string PathyaAahar { get; set; } = null!;
        public string PathyaVihar { get; set; } = null!;
        public string ApathyaAahar { get; set; } = null!;
        public string ApathyaVihar { get; set; } = null!;
        public string SantsangLink { get; set; } = null!;
        public string SadhakAnubhavLink { get; set; } = null!;
        public Guid DiseaseId { get; set; }
        public string DiseaseName { get; set; } = null!;
    }
}
