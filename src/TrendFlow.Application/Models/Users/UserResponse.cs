namespace TrendFlow.Application.Models.Users;

public class UserResponse
{
    public long Id { get; set; }
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
}
