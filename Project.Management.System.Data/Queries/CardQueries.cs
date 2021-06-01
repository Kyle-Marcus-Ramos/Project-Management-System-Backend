using Dapper;
using Project.Management.System.Data.Base;
using Project.Management.System.Model.DTO;
using Project.Management.System.Model.DTO.Common;
using Project.Management.System.Model.Entities;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Project.Management.System.Data.Queries
{
    public class CardQueries : BaseDapperRepository, ICardQueries
    {
        public CardQueries(IDbConnection db) : base(db)
        { }

        public async Task<UpdateCardRequestDTO> GetCardByCardData(UpdateCardRequestDTO updateCardRequestDTO)
        {
            var query = @$"
            SELECT C.* 
            FROM Card C
            WHERE Title = @Title
            AND Description = @Description
            AND IsActive = @IsActive";

            DynamicParameters param = new DynamicParameters();
            param.Add("@Title", updateCardRequestDTO.Title);
            param.Add("@Description", updateCardRequestDTO.Description);
            param.Add("@IsActive", true);

            return await _db.QuerySingleOrDefaultAsync<UpdateCardRequestDTO>(sql: query, param: param, commandType: CommandType.Text);
        }

        public async Task<IEnumerable<GetCardResponseDTO>> GetCardByProjectId(int projectId)
        {
            var query = @$"
            SELECT C.* 
            FROM Card C
            WHERE ProjectId = @ProjectId
            AND IsActive = @IsActive";

            DynamicParameters param = new DynamicParameters();
            param.Add("@ProjectId", projectId);
            param.Add("@IsActive", true);

            return await _db.QueryAsync<GetCardResponseDTO>(sql: query, param: param, commandType: CommandType.Text);
        }

        public async Task<IEnumerable<Cards>> GetCardByStatus(string status)
        {
            var query = @$"
            SELECT C.* 
            FROM Card C
            WHERE Status = @Status
            AND IsActive = @IsActive";

            DynamicParameters param = new DynamicParameters();
            param.Add("@Status", status);
            param.Add("@IsActive", true);

            return await _db.QueryAsync<Cards>(sql: query, param: param, commandType: CommandType.Text);
        }


        public async Task<IEnumerable<GetCalendarByProjectIdResponseDTO>> GetCalendarByProjectId(GetCalendarByProjectIDRequestDTO calendarByProjectIDRequestDTO)
        {
            var query = @$"
            SELECT C.* 
            FROM Card C
            WHERE ProjectId = @ProjectId
            AND IsActive = @IsActive";

            DynamicParameters param = new DynamicParameters();
            param.Add("@ProjectId", calendarByProjectIDRequestDTO.ProjectId);
            param.Add("@IsActive", true);

            return await _db.QueryAsync<GetCalendarByProjectIdResponseDTO>(sql: query, param: param, commandType: CommandType.Text);
        }
    }
}
