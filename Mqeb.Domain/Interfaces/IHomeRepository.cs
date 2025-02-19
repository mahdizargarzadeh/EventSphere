using System.Collections.Generic;
using Mqeb.Domain.Models.Home;
using Mqeb.Domain.ViewModels.Banner;
using Mqeb.Domain.ViewModels.Blog;
using Mqeb.Domain.ViewModels.Home;

namespace Mqeb.Domain.Interfaces
{
    public interface IHomeRepository
    {
        void AddContactUsForm(ContactUs contactUs);
        void AddNewsLetter(string email);
        List<NewsLetter> GetNewsLetter();
        bool EditAboutUs(string description);
        AboutUs GetAboutUs();
        void DeleteBanner(int bannerId);
        List<Banner> GetAllBanners();
        void AddBanner(Banner banner);
        ContactUsForAdminViewModel GetContactUses(int pageId = 1, string filterTitle = "");
        ContactUs GetContactUsMessageById(int contactUsId);
        void TrueIsAnswerContactUs(int contactUsId);
        List<ShowBannerViewModel> GetBannersForShow();
        Banner GetBannerById(int bannerId);
        int GetBannerCount();
    }
}