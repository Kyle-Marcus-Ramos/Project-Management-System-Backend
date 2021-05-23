using Project.Management.System.Data.Base;

namespace Project.Management.System.BusinessLogic.Services.Base
{
    public class BaseService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IUnitOfWorkDapper _unitOfWokDapper;
        protected readonly ILogService _logger;

        public BaseService(IUnitOfWork unitOfWork, IUnitOfWorkDapper unitOfWorkDapper, ILogService logger)
        {
            _unitOfWork = unitOfWork;
            _unitOfWokDapper = unitOfWorkDapper;
            _logger = logger;
        }
    }
}
