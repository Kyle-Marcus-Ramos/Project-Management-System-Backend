namespace Project.Management.System.Data.Base
{
    public interface IUnitOfWorkDapper
    {
        IAccountProjectQueries AccountProjectQueries { get; }
        IAccountQueries AccountQueries { get; }
        ICardQueries CardQueries { get; }
        ICommentQueries CommentQueries { get; }
        IProjectQueries ProjectQueries { get; }
    }
}
