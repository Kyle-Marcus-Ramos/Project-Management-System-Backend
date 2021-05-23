using NLog;
using Project.Management.System.BusinessLogic.Services.Base;
using System;

namespace Project.Management.System.BusinessLogic.Services
{
    public class LoggingService : ILogService
    {
        public void AddEntityToNLog(long? entityId = null, string entityName = null, string additionalInfo = null)
        {
            throw new NotImplementedException();
        }

        public void LogExceptionError(string ex)
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.Info($"Info - { ex }");
        }
    }
}
