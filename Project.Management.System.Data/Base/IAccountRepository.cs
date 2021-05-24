using Project.Management.System.Model.Entities;
using System.Threading.Tasks;

namespace Project.Management.System.Data.Base
{
    public interface IAccountRepository
    {
        Task InsertAccountAsync(Account account);
        Task UpdateAccountAsync(Account account);
        Task SaveChanges();
    }
}
