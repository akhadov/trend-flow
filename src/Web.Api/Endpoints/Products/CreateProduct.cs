using Application.Products.CreateProduct;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Products;

internal sealed class CreateProduct : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("products", async (CreateProductRequest request, ISender sender) =>
        {
            Result<Guid> result = await sender.Send(new CreateProductCommand(request.Name, request.Description, request.ImagePath));

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Products);
    }
}
