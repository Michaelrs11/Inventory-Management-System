using IMS.BE.Models.Masters;
using IMS.BE.Services.Masters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IMS.BE.Pages.Master.Gudang
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly GudangService gudangService;

        [BindProperty]
        public UpdateGudang GudangModel { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;

        public List<SelectListItem> OutletCodeDropdown { get; set; }

        public EditModel(GudangService gudangService)
        {
            this.gudangService = gudangService;
        }

        public async Task<IActionResult> OnGet(string id)
        {
            this.OutletCodeDropdown = await this.gudangService.GetDropdownAsync();
            GudangModel = await this.gudangService.GetSelectedGudangAsync(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            GudangModel.GudangCode = id;

            if (ModelState.IsValid)
            {
                var isNameExists = await this.gudangService.IsUpdateNameExist(GudangModel.Name, id);

                if (isNameExists)
                {
                    GudangModel = await this.gudangService.GetSelectedGudangAsync(id);
                    ErrorMessage = "Name already Exists";
                    return Page();
                }

                await this.gudangService.UpdateAsync(GudangModel, id);
                ErrorMessage = string.Empty;
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
