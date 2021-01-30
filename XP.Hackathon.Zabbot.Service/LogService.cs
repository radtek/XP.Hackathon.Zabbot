using XP.Hackathon.Zabbot.Interface.Repository;
using XP.Hackathon.Zabbot.Interface.Service;
using XP.Hackathon.Zabbot.Model;
using XP.Hackathon.Zabbot.Model.Enums;
using XP.Hackathon.Zabbot.Model.Extensions;
using Newtonsoft.Json;
using System;

namespace XP.Hackathon.Zabbot.Service
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository LogRepository)
        {
            _logRepository = LogRepository;
        }

        public void Insert(Log log)
        {
            _logRepository.Insert(log);
        }

        public void Insert(Exception exp, string step = null)
        {
            try
            {
                var log = new Log();

                log.Message = exp.GetInnerMessages();
                log.Created = DateTimeExtensions.GetBrazilianDate();
                log.LogTypeId = Convert.ToInt32(LogType.Error);

                _logRepository.Insert(log);
            }
            catch (Exception ex)
            {
                // Exceções na geração do log, não deve sobrepor a exceção anterior.
            }
        }

        public void Insert(string message, string step = null)
        {
            try
            {
                var log = new Log();

                log.Message = message;
                log.Created = DateTimeExtensions.GetBrazilianDate();
                log.LogTypeId = Convert.ToInt32(LogType.Error);

                _logRepository.Insert(log);
            }
            catch (Exception ex)
            {
                // Exceções na geração do log, não deve sobrepor a exceção anterior.
            }
        }

        public void Insert(ResultBase result, string message)
        {
            Insert(result, message, null);
        }

        public void Insert(ResultBase result, LogType logType)
        {
            Insert(result, logType, null, null);
        }

        public void Insert(ResultBase result, LogType logType, string message)
        {
            Insert(result, logType, message, null);
        }

        public void Insert(ResultBase result, LogType logType, string message, string step)
        {
            try
            {
                var objectSerialized = JsonConvert.SerializeObject(result);

                var log = new Log();

                log.Message = $"{message} \r {objectSerialized}";
                log.Created = DateTimeExtensions.GetBrazilianDate();
                log.LogTypeId = Convert.ToInt32(logType);

                _logRepository.Insert(log);
            }
            catch (Exception ex)
            {
                // Exceções na geração do log, não deve sobrepor a exceção anterior.
            }
        }

        public void Insert(ResultBase result, string message, string step)
        {
            try
            {
                var objectSerialized = JsonConvert.SerializeObject(result);

                var log = new Log();

                log.Message = $"{message} \r {objectSerialized}" ;
                log.Created = DateTimeExtensions.GetBrazilianDate();
                log.LogTypeId = Convert.ToInt32(LogType.Error);

                _logRepository.Insert(log);
            }
            catch (Exception ex)
            {
                // Exceções na geração do log, não deve sobrepor a exceção anterior.
            }
        }

        public void Insert(Object obj, string message)
        {
            Insert(obj, message, null);
        }

        public void Insert(Object obj, string message, string step)
        {
            try
            {
                var objectSerialized = JsonConvert.SerializeObject(obj);

                var log = new Log();

                log.Message = $"{message} \r {objectSerialized}";
                log.Created = DateTimeExtensions.GetBrazilianDate();
                log.LogTypeId = Convert.ToInt32(LogType.Error);

                _logRepository.Insert(log);
            }
            catch (Exception ex)
            {
                // Exceções na geração do log, não deve sobrepor a exceção anterior.
            }
        }
    }
}

