using Project.Management.System.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Management.System.BusinessLogic.Services.Base
{
    public interface IProjectService
    {
        Task SaveProject(SaveProjectRequestDTO saveProjectRequestDTO);
        Task<IEnumerable<GetProjectByAccountIDResponseDTO>> GetProjectByAccountId(GetProjectByAccountIdRequestDTO getProjectByAccountIdRequestDTO);
    }
}
