namespace Project.Management.System.Model.Entities
{
    public class Activity : BaseEntity
    {
        public int CardId { get; set; }
        public Card Card { get; set; }
        public string Name { get; set; }
    }
}
