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

    // Parameterized constructor
    public Discussion(long productId, Product? product, long userId, User? user, string message, long? parentDiscussionId, Discussion? parentDiscussion, ICollection<Discussion>? replies)
    {
        ProductId = productId;
        Product = product;
        UserId = userId;
        User = user;
        Message = message;
        ParentDiscussionId = parentDiscussionId;
        ParentDiscussion = parentDiscussion;
        Replies = replies;
    }

    // Private parameterless constructor
    private Discussion() { }
}
