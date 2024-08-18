using Hariom.Diseases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Hariom.Web.Pages.Diseases
{
    public class CreateModalModel : HariomPageModel
    {
        [BindProperty]
        public CreateUpdateDiseaseDto Disease { get; set; }
        private readonly IDiseaseAppService _diseaseAppService;
        public CreateModalModel(IDiseaseAppService diseaseAppService)
        {
            _diseaseAppService = diseaseAppService;
        }

        public void OnGet()
        {
            Disease = new CreateUpdateDiseaseDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _diseaseAppService.CreateAsync(Disease);
            return NoContent();
        }
    }
}
