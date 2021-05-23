namespace Project.Management.System.Model.Entities
{
    public class AccountProject : BaseEntity
    {
        public int UserId { get; set; }
        public Account User { get; set; }
        public int ProjectId { get; set; }
        public Projects Project { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
