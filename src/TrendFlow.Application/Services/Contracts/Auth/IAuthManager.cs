using TrendFlow.Domain.Users;

namespace TrendFlow.Application.Services.Contracts.Auth;

public interface IAuthManager
{
    public string GenerateToken(User user);
}