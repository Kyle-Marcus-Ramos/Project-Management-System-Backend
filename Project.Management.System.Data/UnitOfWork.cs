using Project.Management.System.Data.Base;
using Project.Management.System.Data.Context;
using Project.Management.System.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace Project.Management.System.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProjectManagementDBContext _context;
        private bool _isDisposed;

        public UnitOfWork(string connectionString)
        {
            _context = new ProjectManagementDBContext(connectionString);
            AccountRepository = new AccountRepository(_context);
            AccountProjectRepository = new AccountProjectRepository(_context);
            CardRepository = new CardRepository(_context);
            CommentRepository = new CommentRepository(_context);
            ProjectRepository = new ProjectRepository(_context);
        }

        public IAccountRepository AccountRepository { get; private set; }
        public IAccountProjectRepository AccountProjectRepository { get; private set; }
        public ICardRepository CardRepository { get; private set; }
        public ICommentRepository CommentRepository { get; private set; }
        public IProjectRepository ProjectRepository { get; private set; }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    if(_context != null)
                    {
                        _context.Dispose();
                        _context = null;
                    }
                }
            }
            _isDisposed = true;
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
