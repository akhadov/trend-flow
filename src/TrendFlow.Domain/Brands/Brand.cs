using TrendFlow.Domain.Common;

namespace TrendFlow.Domain.Brands;

public class Brand : BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;
}
