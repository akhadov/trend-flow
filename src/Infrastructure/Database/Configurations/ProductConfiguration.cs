using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;
internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.ComplexProperty(
            p => p.Name,
            b => b.Property(e => e.Value).HasColumnName("name"));

        builder.ComplexProperty(
            p => p.Description,
            b => b.Property(e => e.Value).HasColumnName("description"));
    }
}
