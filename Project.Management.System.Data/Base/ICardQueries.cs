using Project.Management.System.Model.DTO;
using Project.Management.System.Model.DTO.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Management.System.Data.Base
{
    public interface ICardQueries
    {
        Task<UpdateCardRequestDTO> GetCardByCardData(UpdateCardRequestDTO updateCardRequestDTO);
        Task<IEnumerable<GetCardResponseDTO>> GetCardByProjectId(int projectId);
        Task<IEnumerable<GetCalendarByProjectIdResponseDTO>> GetCalendarByProjectId(GetCalendarByProjectIDRequestDTO calendarByProjectIDRequestDTO);
        Task<IEnumerable<Cards>> GetCardByStatus(string status);
    }
}
