using Dapper;
using Project.Management.System.Data.Base;
using Project.Management.System.Model.DTO;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Project.Management.System.Data.Queries
{
    public class CommentQueries : BaseDapperRepository, ICommentQueries
    {
        public CommentQueries(IDbConnection db) : base(db)
        { }

        public async Task<IEnumerable<GetCommentByCardIdResponseDTO>> GetCommentByCardId(GetCommentByCardIdRequestDTO getCommentByCardIdRequestDTO)
        {
            var query = @$"
            SELECT C.*, A.*, CA.* 
            FROM Comment C
            INNER JOIN Account A 
            ON C.UserId = A.AccountId
            INNER JOIN Card CA
            ON C.CardId = CA.CardId
            WHERE C.CardId = @CardId
            AND C.IsActive = @IsActive";

            DynamicParameters param = new DynamicParameters();
            param.Add("@CardId", getCommentByCardIdRequestDTO.CardId);
            param.Add("@IsActive", true);

            return await _db.QueryAsync<GetCommentByCardIdResponseDTO>(sql: query, param: param, commandType: CommandType.Text);
        }
    }
}
