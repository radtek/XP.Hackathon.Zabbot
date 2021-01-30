using XP.Hackathon.Zabbot.Interface.Repository.Base;
using XP.Hackathon.Zabbot.Interface.Service;
using XP.Hackathon.Zabbot.Model;
using XP.Hackathon.Zabbot.Model.Extensions;
using XP.Hackathon.Zabbot.Model.Filter;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace XP.Hackathon.Zabbot.Service
{
    public class ServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repository;
        private readonly ILogService _logService;

        public ServiceBase(IRepositoryBase<T> serviceBase, ILogService logService)
        {
            _repository = serviceBase;
            _logService = logService;
        }

        public async Task<Result<T>> GetAsync(long id)
        {
            var result = new Result<T>();

            try
            {
                return await _repository.GetAsync(id);
            }
            catch (Exception ex)
            {
                // Falha.
                result.Success = false;
                result.FriendlyMessage = "An unexpected error has occurred.";
                result.Error = ex;

                _logService.Insert(ex, "ModelService.GetById");
            }

            return result;
        }
        public async Task<Result<T>> GetAsync()
        {
            var result = new Result<T>();

            try
            {
                return await _repository.GetAsync();
            }
            catch (Exception ex)
            {
                // Falha.
                result.Success = false;
                result.FriendlyMessage = "An unexpected error has occurred.";
                result.Error = ex;
                result.MessageLog = ex.GetInnerMessages(); ;

                _logService.Insert(ex, "ModelService.GetAll");
            }

            return result;
        }

        public async Task<Result<T>> GetAsync(BaseFilter filter)
        {
            var result = new Result<T>();

            try
            {
                return await _repository.GetAsync(filter);
            }
            catch (Exception ex)
            {
                // Falha.
                result.Success = false;
                result.FriendlyMessage = "An unexpected error has occurred.";
                result.Error = ex;
                result.MessageLog = ex.GetInnerMessages(); ;

                _logService.Insert(ex, "ModelService.GetAll");
            }

            return result;
        }

        public async Task<Result<T>> SaveAsync(T model)
        {
            var result = new Result<T>();

            try
            {
                return await _repository.SaveAsync(model);
            }
            catch (Exception ex)
            {
                // Falha.
                result.Success = false;
                result.FriendlyMessage = "Failed to complete save.";
                result.Error = ex;

                _logService.Insert(ex, "ModelService.Update");
            }

            return result;
        }
        public async Task<Result<T>> GetAsync(Expression<Func<T, bool>> expression)
        {
            var result = new Result<T>();

            try
            {
                return await _repository.GetAsync(expression);
            }
            catch (Exception ex)
            {
                // Falha.
                result.Success = false;
                result.FriendlyMessage = "An unexpected error has occurred.";
                result.Error = ex;

                _logService.Insert(ex, "ModelService.GetAll");
            }

            return result;
        }
        public async Task<ResultBase> Delete(long id)
        {
            var result = new ResultBase();

            try
            {
                result = await _repository.Delete(id);
            }
            catch (Exception ex)
            {
                // Falha.
                result.Success = false;
                result.FriendlyMessage = "Failed to complete save.";
                result.Error = ex;

                _logService.Insert(ex, "ModelService.Update");
            }

            return result;
        }
        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}

