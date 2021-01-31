namespace XP.Hackathon.Zabbot.Model.Filter
{
    public class BaseFilter
    {
        public BaseFilter()
        {
            Limit = 10;
        }

        public string OrderType { get; set; }
        public string OrderBy { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}

