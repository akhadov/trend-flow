using TrendFlow.Api.Extensions;
using TrendFlow.Application.Models.Brands;
using TrendFlow.Application.Services.Contracts;
using TrendFlow.Application.Services.Implementations;

namespace TrendFlow.Api.Controllers;

public static class BrandEndpoints
{
    public static void MapBrandEndpoints(this IEndpointRouteBuilder route)
    {
        route.MapPost("api/brands", async (CreateBrandRequest request, IBrandService brandService) =>
        {
            var result = await brandService.CreateAsync(request);

            return result.Match(
                onSuccess: response => Results.Ok(response),
                onFailure: error => Results.BadRequest(error));
        });
    }
}
