using TrendFlow.Domain.Common;
using TrendFlow.Domain.Users;

namespace TrendFlow.Domain.Products;

public class Review : BaseAuditableEntity
{
    public decimal Stars { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public long UserId { get; set; }
    public User? User { get; set; }

    public long ProductId { get; set; }
    public Product? Product { get; set; }
}
