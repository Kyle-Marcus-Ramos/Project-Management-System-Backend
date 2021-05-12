namespace Project.Management.System.Model.Entities
{
    public class Comment : BaseEntity
    {
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Comments { get; set; }
    }
}
