using TrendFlow.Application.Models.Users;

namespace TrendFlow.Application.Services.Contracts;

public interface IUserService
{
    Task<bool> UpdateAsync(long id, UserUpdateRequest request);
    Task<bool> DeleteAsync(long id);
    Task<UserResponse> GetIdAsync(long id);
    Task<UserResponse> GetUsernameAsync(string username);
    Task<IEnumerable<UserResponse>> GetAllAsync();
    Task<bool> RoleControlAsync(long userId, ushort roleNum);
}
