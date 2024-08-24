using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;
using Hariom.Treatments;

namespace Hariom.Web.Pages.Treatments
{
    public class EditModalModel : HariomPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateTreatmentDto Treatment { get; set; }

        private readonly ITreatmentAppService _treatmentAppService;

        public EditModalModel(ITreatmentAppService treatmentAppService)
        {
            _treatmentAppService = treatmentAppService;
        }

        public async Task OnGetAsync()
        {
            var treatmentDto = await _treatmentAppService.GetAsync(Id);
            Treatment = ObjectMapper.Map<TreatmentDto, CreateUpdateTreatmentDto>(treatmentDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _treatmentAppService.UpdateAsync(Id, Treatment);
            return NoContent();
        }
    }
}
