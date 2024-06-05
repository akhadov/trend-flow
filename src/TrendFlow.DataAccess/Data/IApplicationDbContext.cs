using Microsoft.EntityFrameworkCore;
using TrendFlow.Domain.Brands;
using TrendFlow.Domain.Categories;
using TrendFlow.Domain.Products;
using TrendFlow.Domain.Users;

namespace TrendFlow.DataAccess.Data;

public interface IApplicationDbContext
{
    DbSet<Brand> Brands { get; set; }
    DbSet<Category> Categories { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<User> Users { get; set; }
}
