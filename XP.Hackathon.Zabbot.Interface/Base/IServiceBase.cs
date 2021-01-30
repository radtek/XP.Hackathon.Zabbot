using XP.Hackathon.Zabbot.Model;
using XP.Hackathon.Zabbot.Model.Filter;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace XP.Hackathon.Zabbot.Interface.Service.Base
{
    public interface IServiceBase<T> where T : class
    {
        Task<Result<T>> GetAsync(long id);
        Task<Result<T>> GetAsync();
        Task<Result<T>> GetAsync(BaseFilter filter);
        Task<Result<T>> GetAsync(Expression<Func<T, bool>> expression);
        Task<Result<T>> SaveAsync(T entity);
        Task<ResultBase> Delete(long id);
        void Dispose();
    }
}
