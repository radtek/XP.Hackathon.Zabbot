using XP.Hackathon.Zabbot.Interface.Repository;
using XP.Hackathon.Zabbot.Model;
using System.Threading.Tasks;

namespace XP.Hackathon.Zabbot.Infrastructure.Data.SqlSever.Repositories
{
    public class LogRepository : RepositoryBase<Log>, ILogRepository
    {
        public async Task Insert(Log log)
        {
            await SaveAsync(log);
        }
    }    
}



