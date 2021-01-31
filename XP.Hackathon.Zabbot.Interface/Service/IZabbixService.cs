using System.Threading.Tasks;
using XP.Hackathon.Zabbot.Model;

namespace XP.Hackathon.Zabbot.Interface.Service
{
    public interface IZabbixService
    {
        Task<ResultBase> ReceiveMessage(ZabbixEvent message);
        Task<ResultBase> SendMessage(AckEvent message);
    }
}