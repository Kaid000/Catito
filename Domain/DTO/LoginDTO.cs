using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class LoginDTO
    {
        [EmailAddress]
        [Required]
        required public string Email { get; set; }

        [PasswordPropertyText]
        [Required]
        required public string Password { get; set; }
    }
}
