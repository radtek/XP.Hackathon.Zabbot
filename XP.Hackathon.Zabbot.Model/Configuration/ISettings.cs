namespace XP.Hackathon.Zabbot.Model.Configuration
{
    public interface ISettings
    {
        string TeamsApi { get; set; }
        TokenConfiguration TokenConfiguration { get; set; }
    }
}
