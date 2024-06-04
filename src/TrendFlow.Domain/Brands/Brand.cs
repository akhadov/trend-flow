using Ardalis.GuardClauses;
using TrendFlow.Domain.Common;

namespace TrendFlow.Domain.Brands;

public class Brand : BaseAuditableEntity
{
    public Brand(string name, string description, string imagePath)
    {
        Guard.Against.NullOrEmpty(name, nameof(name));
        Guard.Against.NullOrEmpty(description, nameof(description));
        Guard.Against.NullOrEmpty(imagePath, nameof(imagePath));

        Name = name;
        Description = description;
        ImagePath = imagePath;
    }

    private Brand() { }

    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string ImagePath { get; private set; } = string.Empty;

    public void Update(string name, string description, string imagePath)
    {
        Guard.Against.NullOrEmpty(name, nameof(name));
        Guard.Against.NullOrEmpty(description, nameof(description));
        Guard.Against.NullOrEmpty(imagePath, nameof(imagePath));

        Name = name;
        Description = description;
        ImagePath = imagePath;
    }
}
