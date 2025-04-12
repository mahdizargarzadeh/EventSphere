using System;
using System.Collections.Generic;
using System.IO;
using Mqeb.Application.DTOs.Banner;
using Mqeb.Application.DTOs.Home;
using Mqeb.Application.Generator;
using Mqeb.Application.Interfaces;
using Mqeb.Application.Sender;
using Mqeb.Application.Utilities;
using Mqeb.Domain.Interfaces;
using Mqeb.Domain.Models.Home;
using Mqeb.Domain.ViewModels.Banner;
using Mqeb.Domain.ViewModels.Home;

namespace Mqeb.Application.Services
{
    public class HomeService: IHomeService
    {
        #region Constractor

        private IHomeRepository _homeRepository;

        public HomeService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        #endregion

        public void AddContactUsForm(ContactUsViewModel contactUs)
        {
            _homeRepository.AddContactUsForm(new ContactUs()
            {
                Email = contactUs.Email,
                Title = contactUs.Title,
                Message = contactUs.Message,
                CreateDate = DateTime.Now,
                IsAnswer = false
            });
        }

        public void AddNewsLetter(string email)
        {
            _homeRepository.AddNewsLetter(email);
        }

        public bool SendNewsLetter(string title, string description)
        {
            var newsLetter = _homeRepository.GetNewsLetter();

            try
            {
                foreach (var item in newsLetter)
                {
                    SendEmail.Send(item.Email,title,description);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditAboutUs(string description)
        {
            return _homeRepository.EditAboutUs(description);
        }

        public AboutUs GetAboutUs()
        {
            return _homeRepository.GetAboutUs();
        }

        public void DeleteBanner(int bannerId)
        {
            var banner = _homeRepository.GetBannerById(bannerId);

            #region DeleteImage

            string deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Banner", banner.BannerImageName);
            if (File.Exists(deleteImagePath))
            {
                File.Delete(deleteImagePath);
            }

            #endregion

            _homeRepository.DeleteBanner(bannerId);
        }

        public List<Banner> GetAllBanners()
        {
            return _homeRepository.GetAllBanners();
        }

        public ContactUsForAdminViewModel GetContactUses(int pageId = 1, string filterTitle = "")
        {
            return _homeRepository.GetContactUses(pageId, filterTitle);
        }

        public ContactUs GetContactUsMessageById(int contactUsId)
        {
            return _homeRepository.GetContactUsMessageById(contactUsId);
        }

        public void TrueIsAnswerContactUs(int contactUsId)
        {
            _homeRepository.TrueIsAnswerContactUs(contactUsId);
        }

        public void AddBanner(CreateBannerViewModel bannerViewModel)
        {
            Banner banner = new Banner()
            {
                BannerImageName = bannerViewModel.BannerImageName,
                BannerLink = bannerViewModel.BannerLink,
                IsDelete = false
            };

            #region SaveImage

            if (bannerViewModel.BannerImage != null && ImageValidation.Validate(bannerViewModel.BannerImage.FileName))
            {
                string imagePath = "";
                banner.BannerImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(bannerViewModel.BannerImage.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Banner", banner.BannerImageName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    bannerViewModel.BannerImage.CopyTo(stream);
                }
            }


            #endregion

            _homeRepository.AddBanner(banner);
        }

        public List<ShowBannerViewModel> GetBannersForShow()
        {
            return _homeRepository.GetBannersForShow();
        }

        public int GetBannerCount()
        {
            return _homeRepository.GetBannerCount();
        }

        public List<NewsLetter> GetNewsLetter()
        {
            return _homeRepository.GetNewsLetter();
        }
    }
}