using Microsoft.EntityFrameworkCore;
using Project.Management.System.Data.Base;
using Project.Management.System.Data.Context;
using Project.Management.System.Model.Entities;
using System.Threading.Tasks;

namespace Project.Management.System.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private ProjectManagementDBContext _projectManagementDBContext 
        {
            get { return _context as ProjectManagementDBContext; }
        }

        public AccountRepository(DbContext context)
            :base(context)
        {   }

        public async Task InsertAccountAsync(Account account)
        {
            await _projectManagementDBContext.Account.AddAsync(account);
        }

        public async Task UpdateAccountAsync(Account account)
        {
            _projectManagementDBContext.Account.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

    }
}
