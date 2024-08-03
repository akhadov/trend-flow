namespace Application.Products.GetProduct;
public sealed record ProductResponse(
    Guid Id,
    string Name,
    string Description,
    string ImagePath);
