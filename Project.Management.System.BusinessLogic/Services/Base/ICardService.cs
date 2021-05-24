using Project.Management.System.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Management.System.BusinessLogic.Services.Base
{
    public interface ICardService
    {
        Task SaveCard(SaveCardRequestDTO saveCardRequestDTO);
        Task UpdateCard(UpdateCardRequestDTO updateCardRequestDTO);
        Task<IEnumerable<GetCardResponseDTO>> GetCardByProjectId(GetCardRequestDTO projectId);
        Task<IEnumerable<GetCalendarByProjectIdResponseDTO>> GetCalendarByProjectId(GetCalendarByProjectIDRequestDTO calendarByProjectIDRequestDTO);
    }
}
