using System.Threading.Tasks;

namespace Project.Management.System.Data.Base
{
    public interface IUnitOfWork
    {
        IAccountProjectRepository AccountProjectRepository { get; }
        IAccountRepository AccountRepository { get; }
        ICardRepository CardRepository { get; }
        ICommentRepository CommentRepository { get; }
        IProjectRepository ProjectRepository { get; }
        Task Complete();
        void Dispose();
    }
}
