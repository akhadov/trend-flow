using System.ComponentModel.DataAnnotations;
using TrendFlow.Application.Attributes;

namespace TrendFlow.Application.Models.Users;

public class UserUpdateRequest
{
    public string Firstname { get; set; } = string.Empty;

    public string Lastname { get; set; } = string.Empty;

    [Required, UsernameCheck]
    public string Username { get; set; } = string.Empty;
}
