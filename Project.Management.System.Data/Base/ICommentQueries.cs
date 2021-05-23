using Project.Management.System.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Management.System.Data.Base
{
    public interface ICommentQueries
    {
        Task<IEnumerable<GetCommentByCardIdResponseDTO>> GetCommentByCardId(GetCommentByCardIdRequestDTO getCommentByCardIdRequestDTO);
    }
}
