using XP.Hackathon.Zabbot.Auth.Auth;
using XP.Hackathon.Zabbot.Infraestructure.Cache.Redis;
using XP.Hackathon.Zabbot.Interface;
using XP.Hackathon.Zabbot.Interface.Cache;
using XP.Hackathon.Zabbot.Interface.Service;
using XP.Hackathon.Zabbot.Interface.Service.Base;
using XP.Hackathon.Zabbot.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using System;

namespace XP.Hackathon.Zabbot.Infrastructure.IoC
{
    public static class SimpleInjectorContainer
    {
        public static Container Container;

        public static void RegisterServices(IServiceCollection services)
        {
            try
            {
                // ASP.NET HttpContext dependency
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

                // Domain
                services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
                services.AddTransient<ILogService, LogService>();
                services.AddTransient<Interface.Service.IUserService, Service.UserService>();
                services.AddTransient<Interface.Service.IProductService, Service.ProductService>();
                services.AddTransient<Interface.Service.IEscalationGroupService, Service.EscalationGroupService>();
                services.AddTransient<Interface.Service.IEscalationService, Service.EscalationService>();

                // SkyNet.Region Domain

                services.AddTransient<ICacheService, RedisService>();
                services.AddTransient<IAuthentication, Authentication>();
                services.AddTransient<Interface.DTO.IUserDTO, DTO.UserDTO>();
                services.AddTransient<Interface.DTO.IProductDTO, DTO.ProductDTO>();
                services.AddTransient<Interface.DTO.IEscalationGroupDTO, DTO.EscalationGroupDTO>();
                services.AddTransient<Interface.DTO.IEscalationDTO, DTO.EscalationDTO>();

                // SkyNet.Region DTO

                // Repository
                services.AddTransient<Interface.Repository.ILogRepository, Data.SqlSever.Repositories.LogRepository>();
                services.AddTransient<Interface.Repository.IUserRepository, Data.SqlSever.Repositories.UserRepository>();
                services.AddTransient<Interface.Repository.IProductRepository, Data.SqlSever.Repositories.ProductRepository>();
                services.AddTransient<Interface.Repository.IEscalationGroupRepository, Data.SqlSever.Repositories.EscalationGroupRepository>();
                services.AddTransient<Interface.Repository.IEscalationRepository, Data.SqlSever.Repositories.EscalationRepository>();

                // SkyNet.Region Repository
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
