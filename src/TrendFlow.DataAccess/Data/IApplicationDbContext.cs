using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendFlow.Domain.Brands;

namespace TrendFlow.DataAccess.Data;

public interface IApplicationDbContext
{
    DbSet<Brand> Brands { get; set; }
}
