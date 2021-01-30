using XP.Hackathon.Zabbot.Model.Extensions;
using System;

namespace XP.Hackathon.Zabbot.Model
{
    [Serializable]
    public class BaseModel
    {
        public BaseModel()
        {
            this.Created = DateTimeExtensions.GetBrazilianDate();
        }

        public long Id { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public virtual bool IsNew()
        {
            return Id == 0;
        }
    }
}


