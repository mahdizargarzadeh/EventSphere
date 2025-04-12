using Microsoft.Extensions.DependencyInjection;
using Mqeb.Application.Convertors;
using Mqeb.Application.Interfaces;
using Mqeb.Application.Services;
using Mqeb.Domain.Interfaces;
using Mqeb.Infra.Data.Repositories;

namespace Mqeb.Infra.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterService(IServiceCollection service)
        {
            #region Repositories

            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IHomeRepository, HomeRepository>();
            service.AddScoped<IBlogRepository, BlogRepository>();
            

            #endregion

            #region Services

            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IHomeService, HomeService>();
            service.AddScoped<IBlogService, BlogService>();
            service.AddScoped<IGoogleRecaptcha, GoogleRecaptcha>();
            service.AddScoped<IViewRenderService, RenderViewToString>();

            #endregion

            #region Tools



            #endregion
        }
    }
}