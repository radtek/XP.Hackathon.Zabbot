using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using XP.Hackathon.Zabbot.Interface.DTO;
using XP.Hackathon.Zabbot.Interface.Service.Base;
using XP.Hackathon.Zabbot.Model;
using XP.Hackathon.Zabbot.Model.Filter;

namespace XP.Hackathon.Zabbot.Api.Controllers
{
    public abstract class BaseController<Model, Message> : BaseHttpController where Model : BaseModel where Message : BaseModel
    {
        private ObjectResult responseMessage;

        public BaseController()
        {
        }

        private readonly IServiceBase<Model> _service;
        private readonly IDTO<Model, Message> _facade;

        public BaseController(IServiceBase<Model> _service, IDTO<Model, Message> facade)
        {
            this._service = _service;
            this._facade = facade;
        }

        [HttpGet("{id}")]
        public async Task<ObjectResult> GetAsync(long id)
        {
            if (id <= 0)
                return await ResponseBadRequest();

            var response = await _service.GetAsync(id);

            if (!response.Success && response.Error != null)
                return await ResponseInternalServerError(response.FriendlyMessage);

            if (!response.Success)
                return await ResponseNotFound();

            return await ResponseOk(_facade.ToMessage(response.Object));
        }

        [HttpGet]
        public async Task<ObjectResult> GetAsync(BaseFilter filter)
        {
            var response = await _service.GetAsync(filter);

            if (!response.Success && response.Error != null)
                return await ResponseInternalServerError(response.FriendlyMessage + response.MessageLog);

            if (!response.Success)
                return await ResponseNotFound();

            return await ResponseOk(_facade.ToMessage(response.Objects));
        }

        [HttpPost]
        public async Task<ObjectResult> PostAsync([FromBody]Message message)
        {
            if (message == null || message.Id > 0)
                return await ResponseBadRequest();

            var response = await _service.SaveAsync(_facade.ToModel(message));

            if (!response.Success)
                return await ResponseInternalServerError(response.FriendlyMessage);

            return await ResponseCreated(_facade.ToMessage(response.Object));
        }

        [HttpPut]
        public async Task<ObjectResult> PutAsync([FromBody]Message message)
        {
            if (message == null || message.Id <= 0)
                return await ResponseBadRequest();

            var response = await _service.SaveAsync(_facade.ToModel(message));

            if (!response.Success && response.Error != null)
                return await ResponseInternalServerError(response.FriendlyMessage);

            if (!response.Success)
                return await ResponseNotFound();

            return await ResponseNoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ObjectResult> DeleteAsync(long id)
        {
            if (id <= 0)
                return await ResponseBadRequest();

            var response = await _service.Delete((long)id);

            if (!response.Success && response.Error != null)
                return await ResponseInternalServerError(response.FriendlyMessage);

            if (!response.Success)
                return await ResponseNotFound();

            return await ResponseNoContent();
        }
    }
}
