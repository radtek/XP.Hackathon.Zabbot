using System;

namespace XP.Hackathon.Zabbot.Model
{
    public class ProductMessage : BaseModel
    {   
        public long SinapiId  { get; set; }
        public string Name  { get; set; }
        public string Unity  { get; set; }
        public decimal AveragePrice  { get; set; }
    }
}
