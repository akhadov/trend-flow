using TrendFlow.Domain.Common;

namespace TrendFlow.Domain.Brands;

public class Brand : BaseAuditableEntity
{
    public Brand(string name, string description, string imagePath) 
    {
        Name = name;
        Description = description;
        ImagePath = imagePath;
    }

    private Brand() { }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public void Update(string name, string description, string imagePath)
    {
        Name = name;
        Description = description;
        ImagePath = imagePath;
    }
}
