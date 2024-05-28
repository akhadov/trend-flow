using TrendFlow.Domain.Common;
using TrendFlow.Domain.Users;

namespace TrendFlow.Domain.Products;

public class Discussion : BaseAuditableEntity
{
    public long ProductId { get; set; }
    public Product? Product { get; set; }

    public long UserId { get; set; }
    public User? User { get; set; }

    public string Message { get; set; } = string.Empty;

    public long? ParentDiscussionId { get; set; }
    public Discussion? ParentDiscussion { get; set; }

    public ICollection<Discussion>? Replies { get; set; }
}
