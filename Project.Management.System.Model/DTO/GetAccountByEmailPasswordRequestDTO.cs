using System.ComponentModel.DataAnnotations;

namespace Project.Management.System.Model.DTO
{
    public class GetAccountByEmailPasswordRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
