using XP.Hackathon.Zabbot.Model;
using System;
using System.Threading.Tasks;

namespace XP.Hackathon.Zabbot.Interface.Cache
{
    public interface ICacheService
    {
        Task<Result<Object>> Get(string key);
        Task<Result<Object>> Get(string key, Type type);
        Task<ResultBase> Push(string key, object value);
        Task<ResultBase> Push(string key, object value, TimeSpan expiration);
        Task<ResultBase> FlushAll();
    }
}
