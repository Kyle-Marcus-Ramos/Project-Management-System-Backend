using Project.Management.System.Model.Entities;
using System.Threading.Tasks;

namespace Project.Management.System.Data.Base
{
    public interface IProjectRepository
    {
        Task InsertProjectAsync(Projects project);
    }
}
