using Project.Management.System.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Management.System.Data.Base
{
    public interface ICardQueries
    {
        Task<UpdateCardRequestDTO> GetCardByCardData(UpdateCardRequestDTO updateCardRequestDTO);
        Task<IEnumerable<GetCardResponseDTO>> GetCardByProjectId(int projectId);
    }
}
