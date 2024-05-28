using TrendFlow.DataAccess.Repositories.Contracts;
using TrendFlow.Domain.Products;

namespace TrendFlow.DataAccess.Repositories.Implementations;

public class ProductRepository(ApplicationDbContext context) : Repository<Product>(context), IProductRepository
{
}
