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
    public UserRole Role { get; set; }

    // Parameterized constructor
    public User(string firstName, string lastName, string username, string email, string password, string passwordSalt, string imagePath, bool isMale, UserRole role)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Email = email;
        Password = password;
        PasswordSalt = passwordSalt;
        ImagePath = imagePath;
        IsMale = isMale;
        Role = role;
    }

    // Private parameterless constructor
    private User() { }
}