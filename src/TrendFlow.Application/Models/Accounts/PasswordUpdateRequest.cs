using System.ComponentModel.DataAnnotations;

namespace TrendFlow.Application.Models.Accounts;

public class PasswordUpdateRequest
{
    [Required]
    public string OldPassword { get; set; } = string.Empty;
    [Required]
    public string NewPassword { get; set; } = string.Empty;
    [Required]
    public string ConfirmPassword { get; set; } = string.Empty;
}
