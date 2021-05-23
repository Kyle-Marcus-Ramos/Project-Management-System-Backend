namespace Project.Management.System.Model.Entities
{
    public class Projects : BaseEntity
    {
        public int UserId { get; set; }
        public Account User { get; set; }
        public string Name { get; set; }
    }
}
