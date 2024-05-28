using TrendFlow.Domain.Common;

namespace TrendFlow.Domain.Users;

public class User : BaseAuditableEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string PasswordSalt { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public bool IsMale { get; set; }
}
