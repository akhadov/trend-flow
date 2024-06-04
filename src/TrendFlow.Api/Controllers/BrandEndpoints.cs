using TrendFlow.Api.Extensions;
using TrendFlow.Application.Models.Brands;
using TrendFlow.Application.Services.Implementations;

namespace TrendFlow.Api.Controllers;

public static class BrandEndpoints
{
    public static void MapBrandEndpoints(this IEndpointRouteBuilder route)
    {
        route.MapPost("api/brands", async (CreateBrandRequest request, BrandService brandService) =>
        {
            var result = await brandService.CreateAsync(request);

            return result.Match(
            onSuccess: () => Results.NoContent(),
            onFailure: error => Results.BadRequest(error));
        });
    }
}
