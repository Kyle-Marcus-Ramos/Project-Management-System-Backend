using Project.Management.System.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Management.System.BusinessLogic.Services.Base
{
    public interface IAccountService
    {
        Task<GetAccountByEmailPasswordResponseDTO> GetAccountByEmailPassword(GetAccountByEmailPasswordRequestDTO accountrequestDTO);
        Task SaveAccount(SaveAccountRequestDTO saveAccountRequestDTO);
        Task<IEnumerable<GetAccountAllResponseDTO>> GetAccountAll();
    }
}
