using Dapper;
using Project.Management.System.Data.Base;
using Project.Management.System.Model.DTO;
using Project.Management.System.Model.Entities;
using System.Data;
using System.Threading.Tasks;

namespace Project.Management.System.Data.Queries
{
    public class AccountQueries : BaseDapperRepository, IAccountQueries
    {
        public AccountQueries(IDbConnection db) : base(db)
        { }

        public async Task<GetAccountByAccountIdResponseDTO> GetAccountByEmail(string email)
        {
            var query = @$"
            SELECT A.* 
            FROM Account A 
            WHERE Email = @Email
            AND IsActive = @IsActive";

            DynamicParameters param = new DynamicParameters();
            param.Add("@Email", email);
            param.Add("@IsActive", true);

            return await _db.QuerySingleOrDefaultAsync<GetAccountByAccountIdResponseDTO>(sql: query, param: param, commandType: CommandType.Text);
        }

        public async Task<GetAccountByEmailPasswordResponseDTO> GetAccountByEmailPassword(GetAccountByEmailPasswordRequestDTO accountrequestDTO)
        {
            var query = @$"
            SELECT A.* 
            FROM Account A 
            WHERE Email = @Email
            AND Password = @Password 
            AND IsActive = @IsActive";

            DynamicParameters param = new DynamicParameters();
            param.Add("@Email", accountrequestDTO.Email);
            param.Add("@Password", accountrequestDTO.Password);
            param.Add("@IsActive", true);

            return await _db.QuerySingleOrDefaultAsync<GetAccountByEmailPasswordResponseDTO>(sql: query, param: param, commandType: CommandType.Text);
        }
    }
}
