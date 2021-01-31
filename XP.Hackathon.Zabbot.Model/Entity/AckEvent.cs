using XP.Hackathon.Zabbot.Model.Enums;

namespace XP.Hackathon.Zabbot.Model
{
    public class AckEvent
    {
        public int EventIds { get; set; }

        public string OperatingUser { get; set; }

        public string Message { get; set; }

        public AckActionEnum Action { get; set; }
    }
}
