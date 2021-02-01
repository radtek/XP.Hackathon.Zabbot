using Newtonsoft.Json;
using XP.Hackathon.Zabbot.Model.Enums;

namespace XP.Hackathon.Zabbot.Model
{
    public class AckEvent
    {
        public string EventId { get; set; }

        public string OperatingUser { get; set; }

        public string Message { get; set; }

        public AckActionEnum Action { get; set; }
    }

    public class ZabbotEvent
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        [JsonProperty("params")]
        public IParams _params { get; set; }
        public string auth { get; set; }
        public int id { get; set; }
        public string result { get; set; }
    }

    public interface IParams
    {}

    public class LoginParams : IParams
    {
        public string user { get; set; }
        public string password { get; set; }
    }

    public class AckParams : IParams
    {
        public string eventids { get; set; }
        public int action { get; set; }
        public string message { get; set; }
    }
}
