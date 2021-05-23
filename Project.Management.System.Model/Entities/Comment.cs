namespace Project.Management.System.Model.Entities
{
    public class Comment : BaseEntity
    {
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int UserId { get; set; }
        public Account User { get; set; }
        public string Comments { get; set; }
    }
}
