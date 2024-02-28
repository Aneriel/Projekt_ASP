using System.ComponentModel.DataAnnotations;

namespace Projekt.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Adres E-Mail użytkownika jest obowiązkowy")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Hasło jest obowiązkowe")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name ="Zapamietaj")]
        public bool RememberMe { get; set; }
    }
}
