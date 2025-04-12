using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mqeb.Application.Convertors;
using Mqeb.Application.DTOs.Home;
using Mqeb.Application.Interfaces;
using Mqeb.Application.Sender;

namespace Mqeb.Web.Pages.Admin.NewsLetter
{
    public class SendNewsLetterModel : AdminBaseRazorPageModel
    {
        #region Constractor

        private IHomeService _homeService;
        private IViewRenderService _viewService;

        public SendNewsLetterModel(IHomeService homeService, IViewRenderService viewService)
        {
            _homeService = homeService;
            _viewService = viewService;
        }

        #endregion

        public SendNewsLetterViewModel SendNewsLetterViewModel { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(SendNewsLetterViewModel.Description))
                {
                    try
                    {
                        SendEmailViewModel model = new SendEmailViewModel();
                        model.Message = SendNewsLetterViewModel.Description;
                        string bodyEmail = _viewService.RenderToStringAsync("_EmailSender", model);

                        var newsLetter = _homeService.GetNewsLetter();

                        foreach (var item in newsLetter)
                        {
                            SendEmail.Send(item.Email, SendNewsLetterViewModel.Title,bodyEmail);
                        }

                        TempData[SuccessMessage] = "پيام با موفقيت ارسال شد";
                        return Redirect("/Admin/AboutUs");
                    }
                    catch
                    {
                        TempData[ErrorMessage] = "مشكلي بوجود آمده است";
                        return Redirect("/Admin/AboutUs");
                    }
                }
                else
                {
                    TempData[ErrorMessage] = "لطفا پيام را وارد نمایید";
                    return Redirect("/Admin/AboutUs");
                }
            }

            return Page();
        }
    }
}
