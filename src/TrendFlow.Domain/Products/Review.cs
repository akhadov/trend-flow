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

    // Parameterized constructor
    public Review(decimal stars, string title, string description, long userId, User? user, long productId, Product? product)
    {
        Stars = stars;
        Title = title;
        Description = description;
        UserId = userId;
        User = user;
        ProductId = productId;
        Product = product;
    }

    // Private parameterless constructor
    private Review() { }
}
