namespace Project.Management.System.Model.DTO
{
    public class GetAccountByAccountIdResponseDTO
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
