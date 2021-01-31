using XP.Hackathon.Zabbot.Interface.DTO;
using XP.Hackathon.Zabbot.Interface.Service;
using XP.Hackathon.Zabbot.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace XP.Hackathon.Zabbot.Api.Controllers
{
    [Route("api/zabbot/[controller]")]
    //[Authorize]
    public class EscalationController : BaseController<Escalation, EscalationMessage>
    {
        public EscalationController(IEscalationService service, IEscalationDTO _facade) : base(service, _facade)
        {
        }

    }
}