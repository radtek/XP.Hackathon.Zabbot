using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace XP.Hackathon.Zabbot.Model
{
    public class User : BaseModel
    {
        public string Login { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public string PasswordStr { get; set; }

        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public DateTime? BirthDate { get; set; }
        public int StatusId { get; set; }
    }
}





