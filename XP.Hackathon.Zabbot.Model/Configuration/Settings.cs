using Newtonsoft.Json;

namespace XP.Hackathon.Zabbot.Model.Configuration
{
    public class Settings : ISettings
    {
        public string TeamsApi { get; set; }
        public TokenConfiguration TokenConfiguration { get; set; }
    }
}
