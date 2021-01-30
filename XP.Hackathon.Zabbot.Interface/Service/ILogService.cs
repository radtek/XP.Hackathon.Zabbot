using XP.Hackathon.Zabbot.Model;
using XP.Hackathon.Zabbot.Model.Enums;
using System;

namespace XP.Hackathon.Zabbot.Interface.Service
{
    public interface ILogService
    {
        void Insert(Log log);
        void Insert(Exception exp, string step = null);
        void Insert(string message, string step = null);
        void Insert(ResultBase result, string message);
        void Insert(ResultBase result, string message, string step);
        void Insert(Object obj, string message);
        void Insert(Object obj, string message, string step);
        void Insert(ResultBase result, LogType logType);
        void Insert(ResultBase result, LogType logType, string message);
        void Insert(ResultBase result, LogType logType, string message, string step);

    }
}
