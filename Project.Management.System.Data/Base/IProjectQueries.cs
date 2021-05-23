using Project.Management.System.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Management.System.Data.Base
{
    public interface IProjectQueries
    {
        Task<IEnumerable<GetProjectByAccountIDResponseDTO>> GetProjectByAccountId(GetProjectByAccountIdRequestDTO getProjectByAccountIdRequestDTO);
    }
}
