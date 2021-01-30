using XP.Hackathon.Zabbot.Interface.DTO;
using XP.Hackathon.Zabbot.Model;
using System.Collections.Generic;
using System.Linq;

namespace XP.Hackathon.Zabbot.DTO
{
    public class UserDTO : IUserDTO
    {
        public User ToModel(UserMessage message)
        {
            var model = new User();

            model.Id = message.Id;
            model.Login = message.Login;
            model.Name = message.Name;
            model.PasswordStr = message.Password;
            model.BirthDate = message.BirthDate;
            model.StatusId = message.StatusId;
            model.Active = message.Active;
            model.Created = message.Created;
            model.Updated = message.Updated;

            return model;
        }

        public UserMessage ToMessage(User model)
        {
            var message = new UserMessage();

            message.Id = model.Id;
            message.Login = model.Login;
            message.Name = model.Name;
            message.BirthDate = model.BirthDate;
            message.StatusId = model.StatusId;
            message.Active = model.Active;
            message.Created = model.Created;
            message.Updated = model.Updated;

            return message;
        }

        public IEnumerable<User> ToModel(IEnumerable<UserMessage> messages)
        {
            if (messages == null || !messages.Any())
                return null;

            var models = new List<User>();

            foreach (var message in messages)
            {
                var model = new User();
                model.Id = message.Id;
                model.Login = message.Login;
                model.Name = message.Name;
                model.PasswordStr = message.Password;
                model.BirthDate = message.BirthDate;
                model.StatusId = message.StatusId;
                model.Active = message.Active;
                model.Created = message.Created;
                model.Updated = message.Updated;

                models.Add(model);
            }

            return models;
        }

        public IEnumerable<UserMessage> ToMessage(IEnumerable<User> models)
        {
            if (models == null || !models.Any())
                return null;

            var messages = new List<UserMessage>();

            foreach (var model in models)
            {
                var message = new UserMessage();

                message.Id = model.Id;
                message.Login = model.Login;
                message.Name = model.Name;
                message.BirthDate = model.BirthDate;
                message.StatusId = model.StatusId;
                message.Active = model.Active;
                message.Created = model.Created;
                message.Updated = model.Updated;

                messages.Add(message);
            }

            return messages;
        }

    }
}
