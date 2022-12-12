using IMS.BE.Commons.Services;
using IMS.BE.Models.Transactions;
using IMS.BE.Services.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IMS.BE.Pages.Transaction
{
    [Authorize]
    public class RekapModel : PageModel
    {
        private readonly RekapTransactionService service;
        private readonly DropdownService dropdown;

        public RekapModel(RekapTransactionService service, DropdownService dropdown)
        {
            this.service = service;
            this.dropdown = dropdown;
        }
        public string? GudangCode { get; set; }
        public List<RekapTransaction> RequestList { set; get; }
        [TempData]
        public string ErrorMessage { get; set; }
        public DateTime? DateFrom { set; get; }
        public DateTime? DateTo { set; get; }

        public Dictionary<string, string> GudangCodeDropdown { get; set; }

        public string GetFormatedDate(DateTime? date)
        {
            if (date.HasValue)
            {
                return date.Value.ToString("yyyy-MM-dd");
            }

            return string.Empty;
        }

        public async Task OnGet(string? gudangCode,
            DateTime? dateFrom,
            DateTime? dateTo)
        {
            GudangCodeDropdown = await this.dropdown.GetGudangDict();

            if (dateFrom > dateTo)
            {
                dateTo = null;
            }

            var requestList = await service.GetRekapTransaction(gudangCode: gudangCode,
                dateFrom: dateFrom,
                dateTo: dateTo);

            RequestList = requestList;
            GudangCode = gudangCode;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }
}
