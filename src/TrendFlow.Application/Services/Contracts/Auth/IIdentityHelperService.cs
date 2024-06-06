using TrendFlow.Domain.Users;

namespace TrendFlow.Application.Services.Contracts.Auth;

public interface IIdentityHelperService
{
    UserRole? GetUserRole();
    long? GetUserId();
    string GetUserName();
    string GetUserEmail();
}
