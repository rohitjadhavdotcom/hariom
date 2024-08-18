using Hariom.Mantras;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Hariom.Web.Pages.Mantras
{
    public class CreateModalModel : HariomPageModel
    {
        [BindProperty]
        public CreateUpdateMantraDto Mantra { get; set; }
        private readonly IMantraAppService _mantraAppService;
        public CreateModalModel(IMantraAppService mantraAppService)
        {
            _mantraAppService = mantraAppService;
        }

        public void OnGet()
        {
            Mantra = new CreateUpdateMantraDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _mantraAppService.CreateAsync(Mantra);
            return NoContent();
        }
    }
}
