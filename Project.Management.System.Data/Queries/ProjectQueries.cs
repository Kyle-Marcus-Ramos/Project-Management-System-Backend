using Dapper;
using Project.Management.System.Data.Base;
using Project.Management.System.Model.DTO;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Project.Management.System.Data.Queries
{
    public class ProjectQueries : BaseDapperRepository, IProjectQueries
    {
        public ProjectQueries(IDbConnection db) : base(db)
        { }

        public async Task<IEnumerable<GetProjectByAccountIDResponseDTO>> GetProjectByAccountId(GetProjectByAccountIdRequestDTO getProjectByAccountIdRequestDTO)
        {
            var query = @$"
            SELECT P.* 
            FROM Project P 
            WHERE UserId = @AccountId
            AND IsActive = @IsActive";

            DynamicParameters param = new DynamicParameters();
            param.Add("@AccountId", getProjectByAccountIdRequestDTO.AccountId);
            param.Add("@IsActive", true);

            return await _db.QueryAsync<GetProjectByAccountIDResponseDTO>(sql: query, param: param, commandType: CommandType.Text);
        }
    }
}
