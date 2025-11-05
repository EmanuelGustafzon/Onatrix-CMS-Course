using System.ComponentModel.DataAnnotations;
using Web.Enums;

namespace Web.ViewModels;

public class CallBackFormViewModel
{
    [Required(ErrorMessage = "Name is required")]
    [Display(Name = "Name")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email address")]
    [Display(Name = "Email")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Phone number is required")]
    [Display(Name = "Phone number")]
    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "Please select a service")]
    [EnumDataType(typeof(ServicesEnum), ErrorMessage = "invalid selection")]
    [Display(Name = "Choose an option")]
    public ServicesEnum SelectOption { get; set; }
}
