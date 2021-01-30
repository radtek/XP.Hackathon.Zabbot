using XP.Hackathon.Zabbot.Interface.Repository;
using XP.Hackathon.Zabbot.Interface.Service;
using XP.Hackathon.Zabbot.Model;

namespace XP.Hackathon.Zabbot.Service
{
    public class EscalationGroupService : ServiceBase<EscalationGroup>, IEscalationGroupService
    {
        public EscalationGroupService(IEscalationGroupRepository repository, ILogService logService) : base(repository, logService)
        {

        }    
    }
}