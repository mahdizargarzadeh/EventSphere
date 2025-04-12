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
using Mqeb.Domain.Models.Home;

namespace Mqeb.Web.Pages.Admin.ContactUses
{
    public class AnswerModel : AdminBaseRazorPageModel
    {
        #region Constractor

        private IHomeService _homeService;
        private IViewRenderService _viewService;

        public AnswerModel(IHomeService homeService, IViewRenderService viewService)
        {
            _homeService = homeService;
            _viewService = viewService;
        }

        #endregion

        public ContactUs ContactUs { get; set; }

        public void OnGet(int id)
        {
            ContactUs = _homeService.GetContactUsMessageById(id);
        }

        public IActionResult OnPost(int contactUsId, string message, string email)
        {
            if (!string.IsNullOrEmpty(message))
            {
                try
                {
                    SendEmailViewModel model = new SendEmailViewModel();
                    model.Message = message;
                    string bodyEmail = _viewService.RenderToStringAsync("_EmailSender", model);
                    SendEmail.Send(email, "پاسخ به پيام شما (موسسه قرآن و عترت بينه)", bodyEmail);

                    _homeService.TrueIsAnswerContactUs(contactUsId);
                    TempData[SuccessMessage] = "پيام با موفقيت ارسال شد";
                    return Redirect("/Admin/Contactus");
                }
                catch
                {
                    TempData[ErrorMessage] = "مشكلي بوجود آمده است";
                    return Redirect("/Admin/ContactUs");
                }
            }

            TempData[ErrorMessage] = "لطفا پيام را وارد نمایید";
            return Redirect("/Admin/ContactUs");
        }
    }
}
