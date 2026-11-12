using System.ComponentModel.DataAnnotations;

namespace Power7.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Email-ul este obligatoriu.")]
    [EmailAddress(ErrorMessage = "Adresă de email invalidă.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Parola este obligatorie.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}

public class RegisterViewModel
{
    [Required(ErrorMessage = "Numele este obligatoriu.")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email-ul este obligatoriu.")]
    [EmailAddress(ErrorMessage = "Adresă de email invalidă.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Parola este obligatorie.")]
    [MinLength(8, ErrorMessage = "Minim 8 caractere.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Confirmă parola.")]
    [Compare("Password", ErrorMessage = "Parolele nu coincid.")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = string.Empty;
}