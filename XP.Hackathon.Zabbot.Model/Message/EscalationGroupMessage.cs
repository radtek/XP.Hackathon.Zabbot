using System;

namespace XP.Hackathon.Zabbot.Model
{
    public class EscalationGroupMessage : BaseModel
    {   
        public string Name  { get; set; }
        public string Email  { get; set; }
        public string TagName  { get; set; }
        public string Channel { get; set; }
    }
}