using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mqeb.Application.Interfaces;
using Mqeb.Domain.Models.Home;

namespace Mqeb.Web.Pages.Admin.Home
{
    public class AboutUsModel : AdminBaseRazorPageModel
    {
        #region Constractor

        private IHomeService _homeService;

        public AboutUsModel(IHomeService homeService)
        {
            _homeService = homeService;
        }

        #endregion

        [BindProperty]
        public AboutUs AboutUs { get; set; }

        public void OnGet()
        {
            AboutUs = _homeService.GetAboutUs();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _homeService.EditAboutUs(AboutUs.AboutDescription);
                TempData[SuccessMessage] = "قسمت درباره موسسه با موفقیت ویرایش شد";
                return Redirect("/Admin");
            }

            return Page();
        }
    }
}
