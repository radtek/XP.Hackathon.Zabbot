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
                services.AddSingleton(typeof(IServiceBase<>), typeof(ServiceBase<>));
                services.AddSingleton<ILogService, LogService>();
                services.AddSingleton<Interface.Service.IUserService, Service.UserService>();
                services.AddSingleton<Interface.Service.IProductService, Service.ProductService>();
                services.AddSingleton<Interface.Service.IEscalationGroupService, Service.EscalationGroupService>();
                services.AddSingleton<Interface.Service.IEscalationService, Service.EscalationService>();

                // SkyNet.Region Domain

                services.AddSingleton<ICacheService, RedisService>();
                services.AddSingleton<IAuthentication, Authentication>();
                services.AddSingleton<Interface.DTO.IUserDTO, DTO.UserDTO>();
                services.AddSingleton<Interface.DTO.IProductDTO, DTO.ProductDTO>();
                services.AddSingleton<Interface.DTO.IEscalationGroupDTO, DTO.EscalationGroupDTO>();
                services.AddSingleton<Interface.DTO.IEscalationDTO, DTO.EscalationDTO>();

                // SkyNet.Region DTO

                // Repository
                services.AddSingleton<Interface.Repository.ILogRepository, Data.SqlSever.Repositories.LogRepository>();
                services.AddSingleton<Interface.Repository.IUserRepository, Data.SqlSever.Repositories.UserRepository>();
                services.AddSingleton<Interface.Repository.IProductRepository, Data.SqlSever.Repositories.ProductRepository>();
                services.AddSingleton<Interface.Repository.IEscalationGroupRepository, Data.SqlSever.Repositories.EscalationGroupRepository>();
                services.AddSingleton<Interface.Repository.IEscalationRepository, Data.SqlSever.Repositories.EscalationRepository>();

                // SkyNet.Region Repository
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
