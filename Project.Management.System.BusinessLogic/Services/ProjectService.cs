using Project.Management.System.BusinessLogic.Services.Base;
using Project.Management.System.Data.Base;
using Project.Management.System.Model.DTO;
using Project.Management.System.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Management.System.BusinessLogic.Helpers;
using System;

namespace Project.Management.System.BusinessLogic.Services
{
    public class ProjectService : BaseService, IProjectService
    {
        public ProjectService(IUnitOfWork unitOfWork, IUnitOfWorkDapper unitOfWorkDapper, ILogService logger)
            : base(unitOfWork, unitOfWorkDapper, logger)
        { }

        public async Task<IEnumerable<GetProjectByAccountIDResponseDTO>> GetProjectByAccountId(GetProjectByAccountIdRequestDTO getProjectByAccountIdRequestDTO)
        {
            try
            {
                return await _unitOfWokDapper.ProjectQueries.GetProjectByAccountId(getProjectByAccountIdRequestDTO);
            }
            catch(Exception ex)
            {
                _logger.LogExceptionError(ex.ToString());
                throw ex;
            }
        }

        public async Task SaveProject(SaveProjectRequestDTO saveProjectRequestDTO)
        {
            GetAccountByAccountIdResponseDTO account = null;
            Projects project = new Projects();
            
            foreach(var email in saveProjectRequestDTO.Email)
            {
                if (!string.IsNullOrEmpty(email))
                {
                    account = await _unitOfWokDapper.AccountQueries.GetAccountByEmail(email) ?? null;
                    
                    if(account != null)
                    {
                        saveProjectRequestDTO.AccountId = account.AccountId;
                        saveProjectRequestDTO.ToEntity(project);
                        await _unitOfWork.ProjectRepository.InsertProjectAsync(project);
                        await _unitOfWork.Complete();
                    }
                }
            }

        }
    }
}
