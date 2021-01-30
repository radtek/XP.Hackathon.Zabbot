using XP.Hackathon.Zabbot.Interface.DTO;
using XP.Hackathon.Zabbot.Interface.Service.Base;
using XP.Hackathon.Zabbot.Model;
using XP.Hackathon.Zabbot.Model.Filter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace XP.Hackathon.Zabbot.Api.Controllers
{
    public abstract class BaseController<Model, Message> : Controller where Model : BaseModel where Message : BaseModel
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



        protected Task<ObjectResult> ResponseOk(object content)
        {
            responseMessage = StatusCode((int)HttpStatusCode.OK, content);
            return Task.FromResult(responseMessage);
        }

        protected Task<ObjectResult> ResponseNotFound(string message = null)
        {
            responseMessage = StatusCode((int)HttpStatusCode.NotFound, message);
            return Task.FromResult(responseMessage);
        }

        protected Task<ObjectResult> ResponseAccepted(object content)
        {
            responseMessage = StatusCode((int)HttpStatusCode.Accepted, content);
            return Task.FromResult(responseMessage);
        }

        protected Task<ObjectResult> ResponseCreated(object message = null)
        {
            responseMessage = StatusCode((int)HttpStatusCode.Created, message);
            return Task.FromResult(responseMessage);
        }

        protected Task<ObjectResult> ResponseNoContent(object response = null)
        {
            responseMessage = StatusCode((int)HttpStatusCode.NoContent, response);
            return Task.FromResult(responseMessage);
        }

        protected Task<ObjectResult> ResponseInternalServerError(string message = null)
        {
            responseMessage = StatusCode((int)HttpStatusCode.InternalServerError, message);
            return Task.FromResult(responseMessage);
        }

        protected Task<ObjectResult> ResponseBadRequest()
        {
            responseMessage = StatusCode((int)HttpStatusCode.BadRequest, null);
            return Task.FromResult(responseMessage);
        }

        protected Task<ObjectResult> ResponseBadRequest(string message)
        {
            responseMessage = StatusCode((int)HttpStatusCode.BadRequest, message);
            return Task.FromResult(responseMessage);
        }

        public long? ParticipantId
        {

            get
            {
                return Convert.ToInt64((HttpContext.User.Claims.FirstOrDefault(x => x.Type == nameof(ParticipantId)) != null ? HttpContext.User.Claims.First(x => x.Type == nameof(ParticipantId)).Value : "0"));
            }
        }

        public long? ProfileId
        {
            get
            {
                return Convert.ToInt64((HttpContext.User.Claims.FirstOrDefault(x => x.Type == nameof(ProfileId)) != null ? HttpContext.User.Claims.First(x => x.Type == nameof(ProfileId)).Value : "0"));
            }
        }

        public List<long> Profiles
        {
            get
            {
                var hasProfile = HttpContext.User.Claims.Any(x => x.Type == "ProfileId");
                if (!hasProfile)
                    return null;

                var profiles = HttpContext.User.Claims.Where(x => x.Type == "ProfileId").Select(x => Convert.ToInt64(x.Value)).ToList();
                return profiles;
            }
        }

        public string GetIpAddress
        {
            get
            {
                string ip = string.IsNullOrEmpty(HttpContext.Request.Headers["IP_ADDRESS"]) ? HttpContext.Connection.RemoteIpAddress.ToString() : HttpContext.Request.Headers["IP_ADDRESS"].ToString();
                return ip;
            }
        }

    }
}
