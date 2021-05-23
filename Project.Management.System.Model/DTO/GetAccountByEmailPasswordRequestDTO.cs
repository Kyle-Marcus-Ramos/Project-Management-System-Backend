using System.ComponentModel.DataAnnotations;

namespace Project.Management.System.Model.DTO
{
    public class GetAccountByEmailPasswordRequestDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
