using XP.Hackathon.Zabbot.Interface;
using XP.Hackathon.Zabbot.Interface.DTO;
using XP.Hackathon.Zabbot.Interface.Service;
using XP.Hackathon.Zabbot.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace XP.Hackathon.Zabbot.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : BaseController<User, UserMessage>
    {
        private readonly IUserService _service;
        private readonly IAuthentication _authentication;
        private readonly IUserDTO _dto;

        public UserController(IUserService service, IAuthentication authentication, IUserDTO dto) : base(service, dto)
        {
            this._service = service;
            this._authentication = authentication;
            this._dto = dto;
        }

        [AllowAnonymous]
        [HttpPost()]
        [Route("authenticate")]
        public async Task<ObjectResult> Authenticate([FromBody]UserMessage message)
        {
            if (message == null)
                return await ResponseBadRequest("Username or password is incorrect.");

            var response = await _service.Authenticate(message.Login, message.Password);
            if (!response.Success || !response.Objects.Any())
                return await ResponseNotFound(response.FriendlyMessage);

            var tokenResponse = _authentication.SetClaims(response.Object);

            return await ResponseOk(tokenResponse);
        }

        [AllowAnonymous]
        [HttpPost()]
        [Route("register")]
        public async Task<ObjectResult> Register([FromBody]UserMessage message)
        {
            if (message == null)
                return await ResponseBadRequest();

            var model = _dto.ToModel(message);

            var response = await _service.Register(model);
            if (!response.Success)
                return await ResponseInternalServerError(response.FriendlyMessage);

            return await ResponseCreated("Inserted successfully!");
        }

    }
}

