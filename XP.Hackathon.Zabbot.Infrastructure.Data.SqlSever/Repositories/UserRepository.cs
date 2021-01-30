using XP.Hackathon.Zabbot.Interface.Repository;
using XP.Hackathon.Zabbot.Model;
using System.Threading.Tasks;

namespace XP.Hackathon.Zabbot.Infrastructure.Data.SqlSever.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public async Task<User> GetByLoginAsync(string login)
        {
            var response = await GetAsync(p => p.Login == login);
            return response.Object;
        }
    }    
}
