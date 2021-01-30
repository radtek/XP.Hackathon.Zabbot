using XP.Hackathon.Zabbot.Interface.Service.Base;
using XP.Hackathon.Zabbot.Model;
using System.Threading.Tasks;

namespace XP.Hackathon.Zabbot.Interface.Service
{
    public interface IUserService : IServiceBase<User>
    {
        Task<ResultBase> Register(User model);

        Task<Result<User>> Authenticate(string login, string passw);
    }
}

