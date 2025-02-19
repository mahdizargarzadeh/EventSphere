using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mqeb.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Mqeb.Application.DTOs.Home;
using Mqeb.Application.Interfaces;
using Mqeb.Domain.Models.Home;
using TopLearn.Core.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mqeb.Web.Controllers
{
    public class HomeController : SiteBaseController
    {
        #region Constractor

        private IHomeService _homeService;
        private IBlogService _blogService;
        private IGoogleRecaptcha _googleRecaptcha;

        public HomeController(IHomeService homeService, IBlogService blogService, IGoogleRecaptcha googleRecaptcha)
        {
            _homeService = homeService;
            _blogService = blogService;
            _googleRecaptcha = googleRecaptcha;
        }

        #endregion

        public IActionResult Index()
        {
            return View(_blogService.GetBlogs());
        }

        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        [Route("ContactUs")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUs(ContactUsViewModel contactUs)
        {
            if (!await _googleRecaptcha.IsSatisfy())
            {
                TempData[WarningMessage] = "اعتبار سنجی captcha نا موفق بود!";
                return View(contactUs);
            }

            if (ModelState.IsValid)
            {
                _homeService.AddContactUsForm(contactUs);
                TempData[SuccessMessage] = "پیام شما با موفقیت ارسال گردید";
                return RedirectToAction("Index");
            }

            return View(contactUs);
        }

        [Route("AboutUs")]
        public IActionResult AboutUs()
        {
            return View(_homeService.GetAboutUs());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewsLetter(string email)
        {
            if (IsEmail.IsValidEmail(email) == true)
            {
                _homeService.AddNewsLetter(email);
                TempData[SuccessMessage] = "شما با موفقیت در خبرنامه موسسه بینه عضو شدید";
            }
            else
            {
                TempData[ErrorMessage] = "ایمیل وارد شده معتبر نمی باشد";
            }

            return Redirect("/");
        }

        [HttpPost]
        [Route("file-upload")]
        public IActionResult UploadImage(IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            if (upload.Length <= 0) return null;

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();

            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/SiteImages",
                fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                upload.CopyTo(stream);
            }

            var url = $"{"/SiteImages/"}{fileName}";

            return Json(new { uploaded = true, url });
        }

        public IActionResult GetSubGroups(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید",Value = ""}
            };

            list.AddRange(_blogService.GetSubCategoryForManageBlog(id));
            return Json(new SelectList(list, "Value", "Text"));
        }

        public JsonResult DropzoneTarget(List<IFormFile> files)
        {
            if (files != null && files.Any())
            {
                List<string> fileNames = new List<string>();

                foreach (var file in files)
                {
                    var fileName = $"{Guid.NewGuid().ToString()}" + Path.GetExtension(file.FileName);

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BlogGallery/");

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    var finalPath = path + fileName;

                    using (var stream = new FileStream(finalPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    fileNames.Add(fileName);
                }
                
                return new JsonResult(new { data = fileNames.ToArray(), status = "Success" });
            }

            return new JsonResult(new { status = "Error" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
