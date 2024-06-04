using Microsoft.EntityFrameworkCore;
using TrendFlow.Domain.Brands;

namespace TrendFlow.DataAccess.Data;

public interface IApplicationDbContext
{
    DbSet<Brand> Brands { get; set; }
}
