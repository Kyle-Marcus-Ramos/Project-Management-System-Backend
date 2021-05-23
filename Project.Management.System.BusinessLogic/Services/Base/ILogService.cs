namespace Project.Management.System.BusinessLogic.Services.Base
{
    public interface ILogService
    {
        void AddEntityToNLog(long? entityId = null, string entityName = null, string additionalInfo = null);
        void LogExceptionError(string ex);
    }
}
