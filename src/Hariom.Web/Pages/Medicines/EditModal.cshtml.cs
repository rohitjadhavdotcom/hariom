using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;
using Hariom.Medicines;

namespace Hariom.Web.Pages.Medicines
{
    public class EditModalModel : HariomPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateMedicineDto Medicine { get; set; }

        private readonly IMedicineAppService _medicineAppService;

        public EditModalModel(IMedicineAppService medicineAppService)
        {
            _medicineAppService = medicineAppService;
        }

        public async Task OnGetAsync()
        {
            var medicineDto = await _medicineAppService.GetAsync(Id);
            Medicine = ObjectMapper.Map<MedicineDto, CreateUpdateMedicineDto>(medicineDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _medicineAppService.UpdateAsync(Id, Medicine);
            return NoContent();
        }
    }
}
