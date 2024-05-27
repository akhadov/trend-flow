using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendFlow.Domain.Brands;
using TrendFlow.Domain.Categories;
using TrendFlow.Domain.Common;

namespace TrendFlow.Domain.Products;

public class Product : BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string ImagePath { get; set; } = string.Empty;

    public long CategoryId { get; set; }
    public Category? Category { get; set; }

    public long BrandId { get; set; }
    public Brand? Brand { get; set; }
}
