using TrendFlow.Domain.Common;

namespace TrendFlow.Domain.Categories;

public class Category : BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;
}
