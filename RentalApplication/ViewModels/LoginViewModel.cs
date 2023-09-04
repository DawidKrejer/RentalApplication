using System.ComponentModel.DataAnnotations;

namespace RentalApplication.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [EmailAddress(ErrorMessage = "Wprowadź poprawny adres e-mail.")]
        [Display(Name = "Adres e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
}
