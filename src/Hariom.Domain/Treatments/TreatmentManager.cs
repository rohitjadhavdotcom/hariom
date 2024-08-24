using Hariom.Medicines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Hariom.Treatments
{
    public class TreatmentManager : DomainService
    {
        private readonly ITreatmentRepository _treatmentRepository;

        public TreatmentManager(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }

        public Treatment Create(
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
            // Creating an instance of the Treatment class
            var treatment = new Treatment(
                aboutDisease,
                diseaseSymptoms,
                diseaseCauses,
                diseaseDiagnose,
                medicineDescription,
                mantraDescription,
                yogupcharDescription,
                otherRemedies,
                immediateTreatment,
                santsangLink,
                sadhakAnubhavLink
            );

            return treatment;
        }
    }
}
