using TrendFlow.DataAccess.Repositories.Contracts;
using TrendFlow.Domain.Products;

namespace TrendFlow.DataAccess.Repositories.Implementations;

public class ReviewRepository(ApplicationDbContext context) : Repository<Review>(context), IReviewRepository
{
}
