using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mqeb.Application.Interfaces;

namespace Mqeb.Web.Pages.Admin.Banner
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

        public List<Domain.Models.Home.Banner> Banners { get; set; }

        public void OnGet()
        {
            Banners = _homeService.GetAllBanners();
        }
    }
}
