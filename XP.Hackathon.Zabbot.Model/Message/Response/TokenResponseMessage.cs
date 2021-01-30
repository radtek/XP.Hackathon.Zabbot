using System;
using System.Collections.Generic;
using System.Text;

namespace XP.Hackathon.Zabbot.Model.Response
{
    public class TokenResponseMessage
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public DateTime created { get; set; }
        public DateTime expires_in { get; set; }
    }
}
