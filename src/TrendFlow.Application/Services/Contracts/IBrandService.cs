using TrendFlow.Application.Models.Brands;
using TrendFlow.Domain.Common.Results;

namespace TrendFlow.Application.Services.Contracts;

public interface IBrandService
{
    Task<Result<IEnumerable<BrandResponse>>> GetAllAsync();
    Task<Result<BrandResponse>> GetByIdAsync(long id);
    Task<Result<BrandResponse>> CreateAsync(CreateBrandRequest request);
    Task<Result> UpdateAsync(long id, UpdateBrandRequest request);
    Task<Result> DeleteAsync(long id);
}