using Project.Management.System.BusinessLogic.Services.Base;
using Project.Management.System.Data.Base;

namespace Project.Management.System.BusinessLogic.Services
{
    public class AccountProjectService : BaseService, IAccountProjectService
    {
        public AccountProjectService(IUnitOfWork unitOfWork, IUnitOfWorkDapper unitOfWorkDapper, ILogService logger)
            : base(unitOfWork, unitOfWorkDapper, logger)
        {   }


    }
}
