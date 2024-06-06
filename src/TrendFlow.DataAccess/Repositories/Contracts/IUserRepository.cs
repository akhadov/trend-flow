using TrendFlow.Domain.Users;

namespace TrendFlow.DataAccess.Repositories.Contracts;

public interface IUserRepository : IRepository<User>
{
    public Task<User?> GetByEmailAsync(string email);

    public Task<User?> GetByUsernameAsync(string username);
}
