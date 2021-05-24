using Dapper;
using Project.Management.System.Data.Base;
using Project.Management.System.Model.DTO;
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
            AND Status = @Status
            AND Assignee = @Assignee
            AND Reporter = @Reporter
            AND Priority = @Priority
            AND IsActive = @IsActive";

            DynamicParameters param = new DynamicParameters();
            param.Add("@Title", updateCardRequestDTO.Title);
            param.Add("@Status", updateCardRequestDTO.Status);
            param.Add("@Assignee", updateCardRequestDTO.Assignee);
            param.Add("@Reporter", updateCardRequestDTO.Reporter);
            param.Add("@Priority", updateCardRequestDTO.Priority);
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
