using TrendFlow.DataAccess.Data;
using TrendFlow.DataAccess.Repositories.Contracts;
using TrendFlow.Domain.Brands;

namespace TrendFlow.DataAccess.Repositories.Implementations;

public class BrandRepository(ApplicationDbContext context) : Repository<Brand>(context), IBrandRepository
{
}
