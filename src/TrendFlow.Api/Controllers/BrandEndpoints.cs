using TrendFlow.Api.Extensions;
using TrendFlow.Application.Models.Brands;
using TrendFlow.Application.Services.Contracts;

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

        route.MapGet("api/brands", async (IBrandService brandService) =>
        {
            var result = await brandService.GetAllAsync();

            return result.Match(
                onSuccess: response => Results.Ok(response),
                onFailure: error => Results.BadRequest(error)
            );
        });

        route.MapGet("api/brands/{id:long}", async (long id, IBrandService brandService) =>
        {
            var result = await brandService.GetByIdAsync(id);

            return result.Match(
                onSuccess: response => Results.Ok(response),
                onFailure: error => Results.BadRequest(error)
            );
        });

        route.MapPut("api/brands/{id:long}", async (long id, UpdateBrandRequest request, IBrandService brandService) =>
        {
            var result = await brandService.UpdateAsync(id, request);

            return result.Match(
                onSuccess: () => Results.NoContent(),
                onFailure: error => Results.BadRequest(error)
            );
        });

        route.MapDelete("api/brands/{id:long}", async (long id, IBrandService brandService) =>
        {
            var result = await brandService.DeleteAsync(id);

            return result.Match(
                onSuccess: () => Results.NoContent(),
                onFailure: error => Results.BadRequest(error)
            );
        });
    }
}
