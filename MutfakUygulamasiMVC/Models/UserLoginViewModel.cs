using System.ComponentModel.DataAnnotations;

namespace MutfakUygulamasiMVC.Models;

public class UserLoginViewModel
{
    [EmailAddress]
    [Required(ErrorMessage = "beni boş bırakma")]
    public string Email { get; set; }
    [Required(ErrorMessage = "beni boş bırakma")]
    public string Password { get; set; }
    public bool KeepMeLoggedIn { get; set; }
}