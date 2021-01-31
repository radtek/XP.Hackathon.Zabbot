using System.Threading.Tasks;
using XP.Hackathon.Zabbot.Interface.Service;
using XP.Hackathon.Zabbot.Model;

namespace XP.Hackathon.Zabbot.Service
{
    public class ZabbixService : IZabbixService
    {
        public ZabbixService(ILogService logService)
        {

        }    

        public async Task<ResultBase> ReceiveMessage(ZabbixEvent message)
        {
            var result = new ResultBase();

            return await Task.FromResult(result);
        }
    }
}