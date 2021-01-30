using XP.Hackathon.Zabbot.Interface.Repository.Base;
using XP.Hackathon.Zabbot.Model;
using XP.Hackathon.Zabbot.Model.Filter;
using System.Threading.Tasks;

namespace XP.Hackathon.Zabbot.Interface.Repository
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<Result<Product>> GetDetailAsync(BaseFilter filter);
    }
}
