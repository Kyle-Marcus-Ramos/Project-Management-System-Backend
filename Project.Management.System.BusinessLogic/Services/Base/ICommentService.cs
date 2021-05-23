using Project.Management.System.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Management.System.BusinessLogic.Services.Base
{
    public interface ICommentService
    {
        Task SaveComment(SaveCommentRequestDTO saveCommentRequestDTO);
        Task<IEnumerable<GetCommentByCardIdResponseDTO>> GetCommentByCardId(GetCommentByCardIdRequestDTO getCommentByCardIdRequestDTO);
    }
}
