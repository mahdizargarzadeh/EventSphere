using System.Collections.Generic;
using Mqeb.Application.DTOs.Banner;
using Mqeb.Application.DTOs.Home;
using Mqeb.Domain.Models.Home;
using Mqeb.Domain.ViewModels.Banner;
using Mqeb.Domain.ViewModels.Home;

namespace Mqeb.Application.Interfaces
{
    public interface IHomeService
    {
        void AddContactUsForm(ContactUsViewModel contactUs);
        void AddNewsLetter(string email);
        bool SendNewsLetter(string title, string description);
        bool EditAboutUs(string description);
        AboutUs GetAboutUs();
        void DeleteBanner(int bannerId);
        List<Banner> GetAllBanners();
        void AddBanner(CreateBannerViewModel bannerViewModel);
        ContactUsForAdminViewModel GetContactUses(int pageId = 1, string filterTitle = "");
        ContactUs GetContactUsMessageById(int contactUsId);
        void TrueIsAnswerContactUs(int contactUsId);
        List<ShowBannerViewModel> GetBannersForShow();
        int GetBannerCount();
        List<NewsLetter> GetNewsLetter();

    }
}