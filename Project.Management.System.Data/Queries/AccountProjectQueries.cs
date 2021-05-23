using Project.Management.System.Data.Base;
using System.Data;

namespace Project.Management.System.Data.Queries
{
    public class AccountProjectQueries : BaseDapperRepository, IAccountProjectQueries
    {
        public AccountProjectQueries(IDbConnection db) : base(db)
        { }
    }
}
