namespace TrendFlow.Application.Models.Brands;

public sealed record CreateBrandRequest(long id, string Name, string Description, string ImagePath);
