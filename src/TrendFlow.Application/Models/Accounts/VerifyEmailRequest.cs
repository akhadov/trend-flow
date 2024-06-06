using System.ComponentModel.DataAnnotations;
using TrendFlow.Application.Attributes;

namespace TrendFlow.Application.Models.Accounts;

public class VerifyEmailRequest
{
    [Required(ErrorMessage = "Email is required"), Email]
    public string Email { get; set; } = string.Empty;

    [Required]
    public int Code { get; set; }
}
