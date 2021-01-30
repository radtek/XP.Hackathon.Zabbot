using System;

namespace XP.Hackathon.Zabbot.Model
{
    public class Escalation : BaseModel
    {
        public int Sequence  { get; set; }
        public string Role  { get; set; }
        public string Name  { get; set; }
        public string Note  { get; set; }
        public long GroupId  { get; set; }
        //public string HourStart  { get; set; }
        //public string HourEnd  { get; set; }
        public TimeSpan HourStart { get; set; }
        public TimeSpan HourEnd { get; set; }

        public string Contact  { get; set; }
        public string Email  { get; set; }
    }
}
