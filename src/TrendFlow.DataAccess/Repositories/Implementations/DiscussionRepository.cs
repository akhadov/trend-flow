using TrendFlow.DataAccess.Repositories.Contracts;
using TrendFlow.Domain.Products;

namespace TrendFlow.DataAccess.Repositories.Implementations;

public class DiscussionRepository(ApplicationDbContext context) : Repository<Discussion>(context), IDiscussionRepository
{
}
