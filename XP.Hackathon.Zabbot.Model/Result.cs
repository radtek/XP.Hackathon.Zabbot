using System;
using System.Collections.Generic;
using System.Linq;

namespace XP.Hackathon.Zabbot.Model
{
    public class ResultBase
    {
        public bool Success { get; set; }

        public string FriendlyMessage { get; set; }

        public string MessageLog { get; set; }

        public Exception Error { get; set; }

        public System.Net.HttpStatusCode HttpStatusCode { get; set; }

        public string Request { get; set; }

        public string Response { get; set; }
    }

    public class Result<T> : ResultBase
    {
        public Result()
        {
            Objects = new List<T>();
        }

        public List<T> Objects { get; set; }

        public T Object
        {
            get
            {
                if (Objects == null || Objects.Count == 0)
                    return default(T);

                return Objects.FirstOrDefault();
            }
        }

        public ResultBase ResultBase
        {
            get
            {
                var result = new ResultBase();

                result.FriendlyMessage = this.FriendlyMessage;
                result.MessageLog = this.MessageLog;
                result.Request = this.Request;
                result.Response = this.Response;
                result.Success = this.Success;               

                return result;
            }

            set { }
        }
    }
}
