using TrendFlow.Domain.Common.Results;

public static class BrandErrors
{
    public static Error NotFound(long brandId) => Error.NotFound(
        "Brands.NotFound",
        $"Brand with id: {brandId} was not found.");
}
