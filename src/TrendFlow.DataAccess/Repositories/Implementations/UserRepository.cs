using TrendFlow.DataAccess.Repositories.Contracts;
using TrendFlow.Domain.Users;

namespace TrendFlow.DataAccess.Repositories.Implementations;

public class UserRepository(ApplicationDbContext context)
    : Repository<User>(context), IUserRepository
{
}
