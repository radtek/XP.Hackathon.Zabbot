using XP.Hackathon.Zabbot.Interface.Repository.Base;
using XP.Hackathon.Zabbot.Model;
using System.Threading.Tasks;

namespace XP.Hackathon.Zabbot.Interface.Repository
{
    public interface ILogRepository : IRepositoryBase<Log>
    {
        Task Insert(Log log);
    }
}

