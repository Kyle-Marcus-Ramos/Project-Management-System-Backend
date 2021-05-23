using Microsoft.Data.SqlClient;
using Project.Management.System.Data.Base;
using Project.Management.System.Data.Queries;
using System;
using System.Data;

namespace Project.Management.System.Data
{
    public class UnitOfWorkDapper : IUnitOfWorkDapper
    {
        private IDbConnection _connection;
        private bool _isDisposed;

        private IAccountQueries _accountQueries;
        private IAccountProjectQueries _accountProjectQueries;
        private ICardQueries _cardQueries;
        private ICommentQueries _commentQueries;
        private IProjectQueries _projectQueries;

        public UnitOfWorkDapper(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public IAccountProjectQueries AccountProjectQueries { get { return _accountProjectQueries ?? new AccountProjectQueries(_connection); } }
        public IAccountQueries AccountQueries { get { return _accountQueries ?? new AccountQueries(_connection); } }
        public ICardQueries CardQueries { get { return _cardQueries ?? new CardQueries(_connection); } }
        public ICommentQueries CommentQueries { get { return _commentQueries ?? new CommentQueries(_connection); } }
        public IProjectQueries ProjectQueries { get { return _projectQueries ?? new ProjectQueries(_connection); } }

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
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
            }
            _isDisposed = true;
        }

        ~UnitOfWorkDapper()
        {
            dispose(false);
        }
    }
}
