namespace Project.Management.System.Model.DTO
{
    public class SaveAccountRequestDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public int UserId { get; set; }
    }
}
