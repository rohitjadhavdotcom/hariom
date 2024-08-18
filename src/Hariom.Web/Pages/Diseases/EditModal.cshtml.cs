using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;
using Hariom.Diseases;

namespace Hariom.Web.Pages.Diseases
{
    public class EditModalModel : HariomPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateDiseaseDto Disease { get; set; }

        private readonly IDiseaseAppService _diseaseAppService;

        public EditModalModel(IDiseaseAppService diseaseAppService)
        {
            _diseaseAppService = diseaseAppService;
        }

        public async Task OnGetAsync()
        {
            var diseaseDto = await _diseaseAppService.GetAsync(Id);
            Disease = ObjectMapper.Map<DiseaseDto, CreateUpdateDiseaseDto>(diseaseDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _diseaseAppService.UpdateAsync(Id, Disease);
            return NoContent();
        }
    }
}
