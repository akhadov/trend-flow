using Application.Abstractions.Messaging;

namespace Application.Products.CreateProduct;
public sealed record CreateProductCommand(
    string Name,
    string Description,
    string ImagePath) : ICommand<Guid>;
