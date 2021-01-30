using System.Collections.Generic;

namespace XP.Hackathon.Zabbot.Interface.DTO
{
    public interface IDTO<Model, Message>  where Message : class where Model : class
    {
        Model ToModel(Message message);
        IEnumerable<Model> ToModel(IEnumerable<Message> messages);
        Message ToMessage(Model model);
        IEnumerable<Message> ToMessage(IEnumerable<Model> models);
    }
}
