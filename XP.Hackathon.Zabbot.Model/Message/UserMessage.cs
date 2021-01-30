using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace XP.Hackathon.Zabbot.Model
{
    public class UserMessage : BaseModel
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public DateTime? BirthDate { get; set; }
        public int StatusId { get; set; }
    }
}
