using Domain.Products;
using Infrastructure.Database;

namespace Infrastructure.Repositories;
internal sealed class ProductRepository(ApplicationDbContext context)
    : Repository<Product>(context), IProductRepository;
