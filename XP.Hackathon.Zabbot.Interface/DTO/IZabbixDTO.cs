using XP.Hackathon.Zabbot.Model;

namespace XP.Hackathon.Zabbot.Interface.DTO
{
    public interface IZabbixDTO
    {
        TeamsEvent GetTeamsMessage(ZabbixEvent input);
    }
}
