using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Products;
using SharedKernel;

namespace Application.Products.CreateProduct;
internal sealed class CreateProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateProductCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Product.Create(
            new Name(request.Name),
            new Description(request.Description),
            request.ImagePath);

        productRepository.Add(product);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}
