using System.ComponentModel.DataAnnotations;

namespace TrendFlow.Application.Models.Accounts;

public class AccountLoginRequest
{
    [Required]
    public string EmailOrUsername { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
