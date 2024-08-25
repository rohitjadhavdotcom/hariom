using Hariom.Diseases;
using Hariom.Mantras;
using Hariom.Medicines;
using Hariom.Treatments;
using Hariom.YogTherapies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Hariom.Web.Pages.Treatments
{
    public class CreateModalModel(ITreatmentAppService treatmentAppService,
        IMedicineRepository medicineRepository,
        IDiseaseRepository diseaseRepository,
        IMantraRepository mantraRepository,
        IYogTherapyRepository yogTherapyRepository) : HariomPageModel
    {
        [BindProperty]
        public CreateUpdateTreatmentViewModel Treatment { get; set; }

        public async void OnGet()
        {
            Treatment = new();

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
            await treatmentAppService.CreateAsync(Treatment);
            return NoContent();
        }
    }

    public class CreateUpdateTreatmentViewModel : CreateUpdateTreatmentDto
    {
        public List<SelectListItem> Diseases { get; set; } = [];
        public List<SelectListItem> Mantras { get; set; } = [];
        public List<SelectListItem> Medicines { get; set; } = [];
        public List<SelectListItem> Yogtheropies { get; set; } = [];
    }
}
