using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mqeb.Application.DTOs.Banner;
using Mqeb.Application.Interfaces;

namespace Mqeb.Web.Pages.Admin.Banner
{
    public class CreateBannerModel : AdminBaseRazorPageModel
    {
        #region Constractor

        private IHomeService _homeService;

        public CreateBannerModel(IHomeService homeService)
        {
            _homeService = homeService;
        }

        #endregion

        [BindProperty]
        public CreateBannerViewModel CreateBannerViewModel { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if(CreateBannerViewModel.BannerImage == null)
                {
                    TempData[ErrorMessage] = "لطفا عکس را وارد کنید";
                    return Page();
                }

                _homeService.AddBanner(CreateBannerViewModel);
                TempData[SuccessMessage] = "بنر با موفقیت اضافه شد";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
