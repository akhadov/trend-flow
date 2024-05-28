using TrendFlow.DataAccess.Repositories.Contracts;
using TrendFlow.Domain.Categories;

namespace TrendFlow.DataAccess.Repositories.Implementations;

public class CategoryRepository(ApplicationDbContext context) : Repository<Category>(context), ICategoryRepository
{
}
