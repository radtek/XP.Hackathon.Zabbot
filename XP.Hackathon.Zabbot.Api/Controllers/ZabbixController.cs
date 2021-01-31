using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using XP.Hackathon.Zabbot.Interface.DTO;
using XP.Hackathon.Zabbot.Interface.Service;
using XP.Hackathon.Zabbot.Model;

namespace XP.Hackathon.Zabbot.Api.Controllers
{
    [Route("api/zabbot/[controller]")]
    //[Authorize]
    public class ZabbixController : BaseHttpController
    {
        private readonly IZabbixService _service;
        public ZabbixController(IZabbixService service, IEscalationDTO escalationDTO)
        {
            this._service = service;
        }

        [HttpPost("SendMessageToTeams")]
        public async Task<ObjectResult> SendMessageToTeams([FromBody] ZabbixEvent message)
        {
            if (message == null || message.Id < 0)
                return await ResponseBadRequest();

            var response = await _service.SendMessageToTeams(message);

            if (!response.Success)
                return await ResponseInternalServerError(response.FriendlyMessage);

            return await ResponseCreated();
        }
    }
}