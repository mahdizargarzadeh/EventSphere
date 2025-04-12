using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mqeb.Application.Interfaces;

namespace Mqeb.Web.Pages.Admin.Banner
{
    public class DeleteBannerModel : AdminBaseRazorPageModel
    {
        #region Constractor

        private IHomeService _homeService;

        public DeleteBannerModel(IHomeService homeService)
        {
            _homeService = homeService;
        }

        #endregion

        public IActionResult OnPostDelete(int bannerId)
        {
            _homeService.DeleteBanner(bannerId);
            TempData[SuccessMessage] = "بنر با موفقیت حذف شد";
            return RedirectToPage("Index");
        }
    }
}
