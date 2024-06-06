namespace TrendFlow.Application.Models.Users;

public class OwnerResponse
{
    public long UserId { get; set; }

    public string FullName { get; set; } = default!;

    public string ImagePath { get; set; } = default!;

    public string Username { get; set; } = default!;
}
