using Microsoft.EntityFrameworkCore;
using Project.Management.System.Data.Base;
using Project.Management.System.Data.Context;
using Project.Management.System.Model.Entities;
using System.Threading.Tasks;

namespace Project.Management.System.Data.Repositories
{
    public class AccountProjectRepository : Repository<AccountProject>, IAccountProjectRepository
    {
        private ProjectManagementDBContext _projectManagementDBContext
        {
            get { return _context as ProjectManagementDBContext; }
        }

        public AccountProjectRepository(DbContext context)
            : base(context)
        { }

        public async Task InsertAccount(AccountProject accountProject)
        {
            await _projectManagementDBContext.AccountProject.AddAsync(accountProject);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

    }
}
