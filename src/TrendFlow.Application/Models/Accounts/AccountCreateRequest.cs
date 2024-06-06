using System.ComponentModel.DataAnnotations;
using TrendFlow.Application.Attributes;

namespace TrendFlow.Application.Models.Accounts;

public class AccountCreateRequest
{
    public string Firstname { get; set; } = string.Empty;

    public string Lastname { get; set; } = string.Empty;


    [Required, Email]
    public string Email { get; set; } = string.Empty;

    [Required, StrongPassword]
    public string Password { get; set; } = string.Empty;

}