using XP.Hackathon.Zabbot.Model;
using XP.Hackathon.Zabbot.Model.Response;

namespace XP.Hackathon.Zabbot.Interface
{
    public interface IAuthentication
    {
        TokenResponseMessage SetClaims(User user);         
    }
}
