using AutoMoq;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using XP.Hackathon.Zabbot.Interface.Repository;
using XP.Hackathon.Zabbot.Interface.Service;
using XP.Hackathon.Zabbot.Model;
using XP.Hackathon.Zabbot.Service;

namespace XP.Hackathon.Zabbot.Tests
{
    public class EscalationGroupFixtureTest
    {
        public Mock<IEscalationGroupRepository> _escalationGroupRepository;
        public Mock<ILogService> _logService;

        public EscalationGroupService GetEscalationGroupMoq()
        {
            var mocker = new AutoMoqer();
            var _escalationGroupService = mocker.Resolve<EscalationGroupService>();

            _escalationGroupRepository = mocker.GetMock<IEscalationGroupRepository>();
            _logService = mocker.GetMock<ILogService>();

            return _escalationGroupService;
        }

        public Task<Result<EscalationGroup>> GetAllEscalationGroup()
        {
            var json = "[{\"Name\":\"Squad Assessoria Web\",\"Email\":\"squad-assessoria-web@xpi.com.br\",\"TagName\":\"SquadAssessoriaWeb\",\"Channel\":\"webhook-xxxxxxxxxxxxxxxxxxxxxxx\",\"Id\":1,\"Active\":true,\"Created\":\"2021-01-30T12:22:21.04\",\"Updated\":\"2021-01-30T15:21:01.41\"},{\"Name\":\"Squad Assessoria Comissões\",\"Email\":\"squad-assessoria-comissoes@xpi.com.br\",\"TagName\":\"SquadAssessoriaComissoes\",\"Channel\":\"canal do teams\",\"Id\":2,\"Active\":true,\"Created\":\"2021-01-30T17:38:38.337\",\"Updated\":null}]";
            var list = JsonConvert.DeserializeObject<List<EscalationGroup>>(json);

            var result = new Result<EscalationGroup>();
            result.Objects.AddRange(list);

            return Task.FromResult(result);
        }
    }
}
