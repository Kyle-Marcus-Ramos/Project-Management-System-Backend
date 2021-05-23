using Project.Management.System.BusinessLogic.Services.Base;
using Project.Management.System.Data.Base;
using Project.Management.System.Model.DTO;
using Project.Management.System.Model.Entities;
using System;
using System.Threading.Tasks;
using Project.Management.System.BusinessLogic.Helpers;

namespace Project.Management.System.BusinessLogic.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(IUnitOfWork unitOfWork, IUnitOfWorkDapper unitOfWorkDapper, ILogService logger)
            : base(unitOfWork, unitOfWorkDapper, logger)
        { }

        public async Task<GetAccountByEmailPasswordResponseDTO> GetAccountByEmailPassword(GetAccountByEmailPasswordRequestDTO accountrequestDTO)
        {
            try
            {
                return await _unitOfWokDapper.AccountQueries.GetAccountByEmailPassword(accountrequestDTO);
            }
            catch(Exception ex)
            {
                _logger.LogExceptionError(ex.ToString());
                throw ex;
            }
        }

        public async Task SaveAccount(SaveAccountRequestDTO saveAccountRequestDTO)
        {
            Account account = new Account();
            try
            {
                if(saveAccountRequestDTO != null)
                {
                    saveAccountRequestDTO.ToEntity(account);
                    await _unitOfWork.AccountRepository.InsertAccountAsync(account);
                }
                await _unitOfWork.Complete();
            }
            catch(Exception ex)
            {
                _logger.LogExceptionError(ex.ToString());
                throw ex;
            }
        }
    }
}
