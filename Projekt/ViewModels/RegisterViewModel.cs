using System.ComponentModel.DataAnnotations;

namespace Projekt.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "Hasła są różne")]
        public string? ConfirmPassword { get; set;}
        public string? Address { get; set; }
    }
}
