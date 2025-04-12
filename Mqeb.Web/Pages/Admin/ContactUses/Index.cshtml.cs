using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mqeb.Application.Interfaces;
using Mqeb.Domain.ViewModels.Home;

namespace Mqeb.Web.Pages.Admin.ContactUses
{
    public class IndexModel : AdminBaseRazorPageModel
    {
        #region Constractor

        private IHomeService _homeService;

        public IndexModel(IHomeService homeService)
        {
            _homeService = homeService;
        }

        #endregion

        public ContactUsForAdminViewModel ContactUsForAdminViewModel { get; set; }

        public void OnGet(int pageId = 1, string filterTitle = "")
        {
            ContactUsForAdminViewModel = _homeService.GetContactUses(pageId,filterTitle);
        }
    }
}
