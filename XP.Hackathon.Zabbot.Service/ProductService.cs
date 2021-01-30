using XP.Hackathon.Zabbot.Interface.Repository;
using XP.Hackathon.Zabbot.Interface.Service;
using XP.Hackathon.Zabbot.Model;
using XP.Hackathon.Zabbot.Model.Filter;
using System;
using System.Threading.Tasks;

namespace XP.Hackathon.Zabbot.Service
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
	 private readonly IProductRepository _repository;
        private readonly ILogService _logService;

        public ProductService(IProductRepository repository, ILogService logService) : base(repository, logService)
        {
            this._repository = repository;
            this._logService = logService;
        }

        public async Task<Result<Product>> GetDetailAsync(BaseFilter filter)
        {
            var result = new Result<Product>();

            try
            {
                return await _repository.GetDetailAsync(filter);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.FriendlyMessage = "An unexpected error has occurred.";
                result.Error = ex;

                _logService.Insert(ex);
            }

            return result;
        }
    }
}
