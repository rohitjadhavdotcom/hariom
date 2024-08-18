using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;
using Hariom.Mantras;

namespace Hariom.Web.Pages.Mantras
{
    public class EditModalModel : HariomPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateMantraDto Mantra { get; set; }

        private readonly IMantraAppService _mantraAppService;

        public EditModalModel(IMantraAppService mantraAppService)
        {
            _mantraAppService = mantraAppService;
        }

        public async Task OnGetAsync()
        {
            var mantraDto = await _mantraAppService.GetAsync(Id);
            Mantra = ObjectMapper.Map<MantraDto, CreateUpdateMantraDto>(mantraDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _mantraAppService.UpdateAsync(Id, Mantra);
            return NoContent();
        }
    }
}
