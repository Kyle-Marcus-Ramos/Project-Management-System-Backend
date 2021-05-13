using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Management.System.Data.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
        Task<TEntity> Get(int id);
    }
}
