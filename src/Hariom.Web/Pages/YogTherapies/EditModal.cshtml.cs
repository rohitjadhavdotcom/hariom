using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;
using Hariom.YogTherapies;

namespace Hariom.Web.Pages.YogTherapies
{
    public class EditModalModel : HariomPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateYogTherapyDto YogTherapy { get; set; }

        private readonly IYogTherapyAppService _yogTherapyAppService;

        public EditModalModel(IYogTherapyAppService yogTherapyAppService)
        {
            _yogTherapyAppService = yogTherapyAppService;
        }

        public async Task OnGetAsync()
        {
            var yogTherapyDto = await _yogTherapyAppService.GetAsync(Id);
            YogTherapy = ObjectMapper.Map<YogTherapyDto, CreateUpdateYogTherapyDto>(yogTherapyDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _yogTherapyAppService.UpdateAsync(Id, YogTherapy);
            return NoContent();
        }
    }
}
