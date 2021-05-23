using Microsoft.EntityFrameworkCore;
using Project.Management.System.Data.Base;
using Project.Management.System.Data.Context;
using Project.Management.System.Model.Entities;
using System.Threading.Tasks;

namespace Project.Management.System.Data.Repositories
{
    public class ProjectRepository : Repository<Projects>, IProjectRepository
    {
        private ProjectManagementDBContext _projectManagementDBContext
        {
            get { return _context as ProjectManagementDBContext; }
        }

        public ProjectRepository(DbContext context)
            : base(context)
        { }

        public async Task InsertProjectAsync(Projects project)
        {
            await _projectManagementDBContext.Project.AddAsync(project);
        }
    }
}
