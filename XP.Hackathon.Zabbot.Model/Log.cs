using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace XP.Hackathon.Zabbot.Model
{
    public class Log : BaseModel
    {
        public Log()
        {
            this.Id = 0;
            this.Created = DateTime.Now;
        }

        public int LogTypeId { get; set; }
        public string Message { get; set; }
        public string StakTrace { get; set; }

        [NotMapped]
        public bool Active { get; set; }

        [NotMapped]
        public DateTime? Updated { get; set; }
    }
}
