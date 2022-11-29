using IMS.BE.Models.Masters;
using IMS.BE.Services.Masters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IMS.BE.Pages.Master
{
    [Authorize]
    public class AddModel : PageModel
    {
        private readonly BarangService barangService;

        public AddModel(BarangService barangService)
        {
            this.barangService = barangService;
        }

        [BindProperty]
        public CreateBarang BarangModel { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var isSkuCodeExists = await this.barangService.IsSKUCodeExists(BarangModel.SkuId);

                var isNameExists = await this.barangService.IsNameExists(BarangModel.Name);

                if (isSkuCodeExists)
                {
                    ErrorMessage = "UserCode already Exists";
                    return Page();
                }

                if (isNameExists)
                {
                    ErrorMessage = "Name already Exists";
                    return Page();
                }

                await this.barangService.InsertAsync(BarangModel);
                ErrorMessage = string.Empty;
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
