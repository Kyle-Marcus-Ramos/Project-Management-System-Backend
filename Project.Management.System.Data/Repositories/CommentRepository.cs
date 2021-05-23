using Microsoft.EntityFrameworkCore;
using Project.Management.System.Data.Base;
using Project.Management.System.Data.Context;
using Project.Management.System.Model.Entities;
using System.Threading.Tasks;

namespace Project.Management.System.Data.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private ProjectManagementDBContext _projectManagementDBContext
        {
            get { return _context as ProjectManagementDBContext; }
        }

        public CommentRepository(DbContext context)
            : base(context)
        { }

        public async Task InsertCommentAsync(Comment comment)
        {
            await _projectManagementDBContext.Comment.AddAsync(comment);
        }
    }
}
