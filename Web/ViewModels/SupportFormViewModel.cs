using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels;

public class SupportFormViewModel
{
    [Required(ErrorMessage = "Email is required")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email address")]
    [Display(Name = "Email")]
    public string Email { get; set; } = null!;
}
