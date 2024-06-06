using Microsoft.EntityFrameworkCore;
using TrendFlow.DataAccess.Data;
using TrendFlow.DataAccess.Repositories.Contracts;
using TrendFlow.Domain.Users;

namespace TrendFlow.DataAccess.Repositories.Implementations;

public class UserRepository(ApplicationDbContext context)
    : Repository<User>(context), IUserRepository
{
    public async Task<User?> GetByEmailAsync(string email)
            => await context.Users.FirstOrDefaultAsync(user => user.Email == email);

    public async Task<User?> GetByUsernameAsync(string username)
        => await context.Users.FirstOrDefaultAsync(user => user.Username == username);
}
