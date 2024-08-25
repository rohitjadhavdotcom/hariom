using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;
using Hariom.Treatments;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Hariom.Diseases;
using Hariom.Mantras;
using Hariom.Medicines;
using Hariom.YogTherapies;

namespace Hariom.Web.Pages.Treatments
{
    public class EditModalModel(ITreatmentAppService treatmentAppService, ITreatmentRepository treatmentRepository,
        IMedicineRepository medicineRepository,
        IDiseaseRepository diseaseRepository,
        IMantraRepository mantraRepository,
        IYogTherapyRepository yogTherapyRepository) : HariomPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        public string DiseaseName { get; set; }

        [BindProperty]
        public CreateUpdateTreatmentViewModel Treatment { get; set; }


        public async Task OnGetAsync()
        {
            var treatmentDto = await treatmentAppService.GetByIdAsync(Id);
            DiseaseName = treatmentDto.DiseaseName;
            var createUpdateTreatmentViewModel = new CreateUpdateTreatmentViewModel
            {
                AboutDisease = treatmentDto.AboutDisease,
                ApathyaAahar = treatmentDto.ApathyaAahar,
                ApathyaVihar = treatmentDto.ApathyaVihar,
                DiseaseCauses = treatmentDto.DiseaseCauses,
                DiseaseDiagnose = treatmentDto.DiseaseDiagnose,
                DiseaseSymptoms = treatmentDto.DiseaseSymptoms,
                ImmediateTreatment = treatmentDto.ImmediateTreatment,
                MantraDescription = treatmentDto.MantraDescription,
                MedicineDescription = treatmentDto.MedicineDescription,
                OtherRemedies = treatmentDto.OtherRemedies,
                PathyaAahar = treatmentDto.PathyaAahar,
                SadhakAnubhavLink = treatmentDto.SadhakAnubhavLink,
                SantsangLink = treatmentDto.SantsangLink,
                PathyaVihar = treatmentDto.PathyaVihar,
                YogupcharDescription = treatmentDto.YogupcharDescription,
                DiseaseId = treatmentDto.DiseaseId,
                SelectedMantras = treatmentDto.Mantras.Select(i => i.Id).ToList(),
                SelectedMedicines = treatmentDto.Medicines.Select(i => i.Id).ToList(),
                SelectedYogtheropies = treatmentDto.YogTherapies.Select(i => i.Id).ToList(),
            };

            Treatment = createUpdateTreatmentViewModel;

            Treatment.Medicines = (await medicineRepository.GetListAsync())
                .Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                }).ToList();

            Treatment.Diseases = (await diseaseRepository.GetListAsync())
                .Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                }).ToList();

            Treatment.Mantras = (await mantraRepository.GetListAsync())
                .Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                }).ToList();

            Treatment.Yogtheropies = (await yogTherapyRepository.GetListAsync())
                .Select(i => new SelectListItem
                {
                    Text = i.YogopcharTherapy,
                    Value = i.Id.ToString(),
                }).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await treatmentAppService.UpdateAsync(Id, Treatment);
            return NoContent();
        }
    }
}
