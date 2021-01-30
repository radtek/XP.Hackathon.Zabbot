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
        //private readonly IEscalationService _service;
        //private readonly IDTO<Escalation, EscalationMessage> _productDTO;
        public EscalationController(IEscalationService service, IEscalationDTO escalationDTO) : base(service, escalationDTO)
        {
            //this._service = service;
            //this._productDTO = escalationDTO;
        }

    }
}