using XP.Hackathon.Zabbot.Interface.Service.Base;
using XP.Hackathon.Zabbot.Model;
using XP.Hackathon.Zabbot.Model.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XP.Hackathon.Zabbot.Interface.Service
{
    public interface IProductService : IServiceBase<Product>
    {
        Task<Result<Product>> GetDetailAsync(BaseFilter filter);
    }
}
