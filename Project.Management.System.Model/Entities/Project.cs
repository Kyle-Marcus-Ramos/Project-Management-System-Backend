namespace Project.Management.System.Model.Entities
{
    public class Project : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
    }
}
