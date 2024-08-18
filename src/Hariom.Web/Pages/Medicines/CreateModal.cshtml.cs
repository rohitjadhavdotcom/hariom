using Hariom.Medicines;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Hariom.Web.Pages.Medicines
{
    public class CreateModalModel : HariomPageModel
    {
        [BindProperty]
        public CreateUpdateMedicineDto Medicine { get; set; }
        private readonly IMedicineAppService _medicineAppService;
        public CreateModalModel(IMedicineAppService medicineAppService)
        {
            _medicineAppService = medicineAppService;
        }

        public void OnGet()
        {
            Medicine = new CreateUpdateMedicineDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _medicineAppService.CreateAsync(Medicine);
            return NoContent();
        }
    }
}
