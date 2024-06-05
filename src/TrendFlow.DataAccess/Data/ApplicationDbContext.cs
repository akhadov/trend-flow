using Microsoft.EntityFrameworkCore;
using TrendFlow.Domain.Brands;
using TrendFlow.Domain.Categories;
using TrendFlow.Domain.Products;
using TrendFlow.Domain.Users;

namespace TrendFlow.DataAccess.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}