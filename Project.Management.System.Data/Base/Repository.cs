using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Management.System.Data.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        
        public Repository(DbContext context)
        {
            this._context = context;
        }

        public async Task Add(TEntity entity)
        {
            await this._context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            await this._context.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task<TEntity> Get(int id)
        {
            return await this._context.Set<TEntity>().FindAsync(id);
        }
    }
}
