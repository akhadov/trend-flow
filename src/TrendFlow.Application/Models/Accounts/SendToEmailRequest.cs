using System.ComponentModel.DataAnnotations;
using TrendFlow.Application.Attributes;

namespace TrendFlow.Application.Models.Accounts;

public class SendToEmailRequest
{
    [Required(ErrorMessage = "Email is required"), Email]
    public string Email { get; set; } = string.Empty;
}
