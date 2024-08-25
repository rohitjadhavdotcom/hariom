using Hariom.Medicines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hariom.Treatments
{
    public class Treatment : AuditedAggregateRoot<Guid>
    {
        public Guid DiseaseId { get; set; }
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

        private Treatment()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Treatment(
            string aboutDisease,
            string diseaseSymptoms,
            string diseaseCauses,
            string diseaseDiagnose,
            string medicineDescription,
            string mantraDescription,
            string yogupcharDescription,
            string otherRemedies,
            string immediateTreatment,
            string santsangLink,
            string sadhakAnubhavLink)
        {
            AboutDisease = aboutDisease;
            DiseaseSymptoms = diseaseSymptoms;
            DiseaseCauses = diseaseCauses;
            DiseaseDiagnose = diseaseDiagnose;
            MedicineDescription = medicineDescription;
            MantraDescription = mantraDescription;
            YogupcharDescription = yogupcharDescription;
            OtherRemedies = otherRemedies;
            ImmediateTreatment = immediateTreatment;
            SantsangLink = santsangLink;
            SadhakAnubhavLink = sadhakAnubhavLink;
        }

    }
}
