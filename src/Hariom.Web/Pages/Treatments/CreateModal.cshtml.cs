using Hariom.Treatments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Hariom.Web.Pages.Treatments
{
    public class CreateModalModel : HariomPageModel
    {
        [BindProperty]
        public CreateUpdateTreatmentDto Treatment { get; set; }
        private readonly ITreatmentAppService _treatmentAppService;
        public CreateModalModel(ITreatmentAppService treatmentAppService)
        {
            _treatmentAppService = treatmentAppService;
        }

        public void OnGet()
        {
            Treatment = new CreateUpdateTreatmentDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _treatmentAppService.CreateAsync(Treatment);
            return NoContent();
        }
    }
}
