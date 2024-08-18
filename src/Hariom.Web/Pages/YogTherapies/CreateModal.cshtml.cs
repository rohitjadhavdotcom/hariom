using Hariom.YogTherapies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Hariom.Web.Pages.YogTherapies
{
    public class CreateModalModel : HariomPageModel
    {
        [BindProperty]
        public CreateUpdateYogTherapyDto YogTherapy { get; set; }
        private readonly IYogTherapyAppService _yogTherapyAppService;
        public CreateModalModel(IYogTherapyAppService yogTherapyAppService)
        {
            _yogTherapyAppService = yogTherapyAppService;
        }

        public void OnGet()
        {
            YogTherapy = new CreateUpdateYogTherapyDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _yogTherapyAppService.CreateAsync(YogTherapy);
            return NoContent();
        }
    }
}
