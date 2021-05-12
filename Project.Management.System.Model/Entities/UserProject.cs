namespace Project.Management.System.Model.Entities
{
    public class UserProject : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
