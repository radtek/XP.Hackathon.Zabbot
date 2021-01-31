using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using XP.Hackathon.Zabbot.Interface.DTO;
using XP.Hackathon.Zabbot.Interface.Service.Base;
using XP.Hackathon.Zabbot.Model;
using XP.Hackathon.Zabbot.Model.Filter;

namespace XP.Hackathon.Zabbot.Api.Controllers
{
    public abstract class BaseHttpController : Controller
    {
        private ObjectResult responseMessage;

        public BaseHttpController()
        {
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
