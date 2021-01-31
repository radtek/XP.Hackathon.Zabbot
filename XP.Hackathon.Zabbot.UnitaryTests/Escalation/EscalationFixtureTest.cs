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
    public class EscalationFixtureTest
    {
        public Mock<IEscalationRepository> _escalationRepository;
        public Mock<ILogService> _logService;

        public EscalationService GetEscalationMoq()
        {
            var mocker = new AutoMoqer();
            var _escalationGroupService = mocker.Resolve<EscalationService>();

            _escalationRepository = mocker.GetMock<IEscalationRepository>();
            _logService = mocker.GetMock<ILogService>();

            return _escalationGroupService;
        }

        public Task<Result<Escalation>> GetAllEscalation()
        {
            var json = "[{\"Sequence\":\"1\",\"Role\":\"Analista\",\"Name\":\"Lucas Carvalho\",\"Note\":\"1(11) 988775544\",\"GroupId\":\"1\",\"HourStart\":null,\"HourEnd\":null,\"Contact\":\"1\",\"Email\":\"1(11) 988775544\",\"Id\":1,\"Active\":false,\"Created\":\"2021-01-30T20:04:03.997\",\"Updated\":\"2021-01-30T20:13:28.323\"},{\"Sequence\":\"2\",\"Role\":\"Analista\",\"Name\":\"Diego Bertti\",\"Note\":null,\"GroupId\":\"1\",\"HourStart\":null,\"HourEnd\":null,\"Contact\":\"(11) 988775544\",\"Email\":\"l\",\"Id\":2,\"Active\":true,\"Created\":\"2021-01-30T20:14:01.42\",\"Updated\":null},{\"Sequence\":\"1\",\"Role\":\"Analista\",\"Name\":\"Vitor Tupam\",\"Note\":null,\"GroupId\":\"1\",\"HourStart\":null,\"HourEnd\":null,\"Contact\":\"(11) 988775544\",\"Email\":\"vitor.tupam@xpi.com.br\",\"Id\":3,\"Active\":false,\"Created\":\"2021-01-30T20:17:36.183\",\"Updated\":\"2021-01-30T20:21:49.833\"},{\"Sequence\":\"1\",\"Role\":\"Analista\",\"Name\":\"Henrique Souza\",\"Note\":null,\"GroupId\":\"1\",\"HourStart\":null,\"HourEnd\":null,\"Contact\":\"(11) 988775544\",\"Email\":\"henrique.souza@xpi.com.br\",\"Id\":4,\"Active\":false,\"Created\":\"2021-01-30T20:22:55.453\",\"Updated\":null}]";
            var list = JsonConvert.DeserializeObject<List<Escalation>>(json);

            var result = new Result<Escalation>();
            result.Objects.AddRange(list);

            return Task.FromResult(result);
        }
    }
}
