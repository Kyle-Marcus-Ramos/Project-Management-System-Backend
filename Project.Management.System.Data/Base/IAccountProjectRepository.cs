using Project.Management.System.Model.Entities;
using System.Threading.Tasks;

namespace Project.Management.System.Data.Base
{
    public interface IAccountProjectRepository
    {
        Task InsertAccount(AccountProject accountProject);
        Task SaveChanges();
    }
}
