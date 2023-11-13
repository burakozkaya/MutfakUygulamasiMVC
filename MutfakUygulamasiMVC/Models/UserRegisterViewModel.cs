using System.ComponentModel.DataAnnotations;

namespace MutfakUygulamasiMVC.Models;

public class UserRegisterViewModel
{
    [EmailAddress]
    [Required(ErrorMessage = "Beni boş bırakma")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Beni boş bırakma")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Beni boş bırakma")]
    public string ConfirmPassword { get; set; }
}