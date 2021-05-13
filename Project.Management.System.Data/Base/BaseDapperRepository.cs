using System.Data;

namespace Project.Management.System.Data.Base
{
    public class BaseDapperRepository
    {
        protected IDbConnection _db { get; set; }
        public BaseDapperRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}
