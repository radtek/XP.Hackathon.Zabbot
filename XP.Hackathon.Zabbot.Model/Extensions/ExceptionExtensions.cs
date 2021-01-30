using System;
using System.Text;

namespace XP.Hackathon.Zabbot.Model.Extensions
{
    public static class ExceptionExtensions
    {
        public static string GetInnerMessages(this Exception ex)
        {
            var sb = new StringBuilder();

            do
            {
                sb.AppendLine("Error Message: " + ex.Message);
                sb.AppendLine("Stack Trace: " + ex.StackTrace);

                if (ex.InnerException != null)
                {
                    sb.AppendLine();
                    sb.AppendLine("InnerException:");
                }

                ex = ex.InnerException;
            }
            while (ex != null);

            return sb.ToString();
        }
    }
}
