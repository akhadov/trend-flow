using Microsoft.EntityFrameworkCore;
using TrendFlow.Domain.Brands;

namespace TrendFlow.DataAccess.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Brand> Brands { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}