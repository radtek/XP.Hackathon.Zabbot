using System.Threading.Tasks;
using XP.Hackathon.Zabbot.Model;

namespace XP.Hackathon.Zabbot.Interface.Service
{
    public interface IZabbixService
    {
        Task<ResultBase> SendMessageToTeams(ZabbixEvent message);
        Task<ResultBase> SendMessageToZabbix(AckEvent message);
    }
}