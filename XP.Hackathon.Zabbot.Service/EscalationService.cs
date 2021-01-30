using XP.Hackathon.Zabbot.Interface.Repository;
using XP.Hackathon.Zabbot.Interface.Service;
using XP.Hackathon.Zabbot.Model;

namespace XP.Hackathon.Zabbot.Service
{
    public class EscalationService : ServiceBase<Escalation>, IEscalationService
    {
        public EscalationService(IEscalationRepository repository, ILogService logService) : base(repository, logService)
        {

        }    
    }
}