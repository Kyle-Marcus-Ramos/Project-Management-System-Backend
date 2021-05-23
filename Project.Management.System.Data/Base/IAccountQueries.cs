using Project.Management.System.Model.DTO;
using Project.Management.System.Model.Entities;
using System.Threading.Tasks;

namespace Project.Management.System.Data.Base
{
    public interface IAccountQueries
    {
        Task<GetAccountByEmailPasswordResponseDTO> GetAccountByEmailPassword(GetAccountByEmailPasswordRequestDTO accountDTO);
        Task<GetAccountByAccountIdResponseDTO> GetAccountByEmail(string email);
    }
}
