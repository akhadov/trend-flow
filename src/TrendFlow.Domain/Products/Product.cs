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

    // Parameterized constructor
    public Product(string name, string description, decimal price, string imagePath, long categoryId, Category? category, long brandId, Brand? brand)
    {
        Name = name;
        Description = description;
        Price = price;
        ImagePath = imagePath;
        CategoryId = categoryId;
        Category = category;
        BrandId = brandId;
        Brand = brand;
    }

    // Private parameterless constructor
    private Product() { }
}
