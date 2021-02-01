using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XP.Hackathon.Zabbot.Interface.DTO;
using XP.Hackathon.Zabbot.Interface.Service;
using XP.Hackathon.Zabbot.Model;
using Flurl.Http;
using Newtonsoft.Json;
using System.Linq;

namespace XP.Hackathon.Zabbot.Service
{
    public class ZabbixService : IZabbixService
    {
        private readonly IZabbixDTO _facade;
        private readonly ILogService _logService;
        private readonly IEscalationGroupService _escaltionGroupService;
        private readonly ZabbotEvent _zabbixLoginCredentials;
        private readonly string zabbixURL = "http://opti.xpinc.io/zabbix-hml/api_jsonrpc.php";

        public ZabbixService(ILogService logService, IZabbixDTO facade, IEscalationGroupService escaltionGroupService)
        {
            _logService = logService;
            _facade = facade;
            _escaltionGroupService = escaltionGroupService;
            _zabbixLoginCredentials = new ZabbotEvent()
            {
                jsonrpc = "2.0",
                method = "user.login",
                _params = new LoginParams()
                {
                    user = "user_zabbot",
                    password = "user_zabbot"
                },
                id = 1
            };
        }    

        public async Task<ResultBase> SendMessageToTeams(ZabbixEvent message)
        {
            var result = new ResultBase();
            var teamsMessage = _facade.GetTeamsMessage(message);

            var escGroupResult = await _escaltionGroupService.GetAsync(x => x.TagName == message.TagNameGroup);

            if (!escGroupResult.Success || !escGroupResult.Objects.Any())
                return result;


            string url = escGroupResult.Object.Channel;
            var stringContent = JsonConvert.SerializeObject(message);
            await PostAsync(url, stringContent);

            result.Success = true;

            return await Task.FromResult(result);
        }

        public async Task<ResultBase> SendMessageToZabbix(AckEvent message)
        {
            var result = new ResultBase();

            var stringContent = JsonConvert.SerializeObject(_zabbixLoginCredentials);
            var loginAuth = await PostAsync<ZabbotEvent>(zabbixURL, stringContent);

            if (string.IsNullOrWhiteSpace(loginAuth.result))
            {
                return result;
            }

            _facade.GetZabbotAckEvent(message, loginAuth);
            stringContent = JsonConvert.SerializeObject(loginAuth);
            await PostAsync(zabbixURL, stringContent);

            result.Success = true;

            return await Task.FromResult(result);
        }
        

        public async Task PostAsync(string url, string stringContent)
        {
            try
            {
                using (var ct = new CancellationTokenSource())
                {
                    ct.CancelAfter(TimeSpan.FromSeconds(20000));

                    var httpContent = new StringContent(stringContent, Encoding.UTF8, "application/json");

                    var resultHttp = await url.PostAsync(httpContent, ct.Token);

                    var resultString = await resultHttp.Content?.ReadAsStringAsync();

                    if (!resultHttp.IsSuccessStatusCode)
                    {
                        string message = $"A API não obteve um retorno esperado. - Content: {resultString} - ReasonPhrase: {resultHttp.ReasonPhrase} - RequestMessage: {resultHttp.RequestMessage}";
                        _logService.Insert(message);
                    }
                }
            }
            catch (Exception ex)
            {
                _logService.Insert(ex);
            }
        }

        public async Task<T> PostAsync<T>(string url, string stringContent)
        {
            try
            {
                using (var ct = new CancellationTokenSource())
                {
                    ct.CancelAfter(TimeSpan.FromSeconds(20000));

                    var httpContent = new StringContent(stringContent, Encoding.UTF8, "application/json");

                    var resultHttp = await url.PostAsync(httpContent, ct.Token);

                    var resultString = await resultHttp.Content?.ReadAsStringAsync();

                    if (!resultHttp.IsSuccessStatusCode)
                    {
                        string message = $"A API não obteve um retorno esperado. - Content: {resultString} - ReasonPhrase: {resultHttp.ReasonPhrase} - RequestMessage: {resultHttp.RequestMessage}";
                        _logService.Insert(message);
                        return default;
                    }

                    return JsonConvert.DeserializeObject<T>(resultString);
                }
            }
            catch (Exception ex)
            {
                _logService.Insert(ex);
                return default;
            }
        }
    }
}