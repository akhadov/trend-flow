using Application.Products.GetProduct;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Products;

internal sealed class GetProduct : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("products/{id}", async (Guid id, ISender sender) =>
        {
            Result<ProductResponse> result = await sender.Send(new GetProductQuery(id));

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Products);
    }
}
