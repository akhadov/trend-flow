using TrendFlow.Application.Models.Categories;
using TrendFlow.Domain.Common.Results;

namespace TrendFlow.Application.Services.Contracts;

public interface ICategoryService
{
    Task<Result<IEnumerable<CategoryResponse>>> GetAllAsync();
    Task<Result<CategoryResponse>> GetByIdAsync(long id);
    Task<Result<CategoryResponse>> CreateAsync(CreateCategoryRequest request);
    Task<Result> UpdateAsync(long id, UpdateCategoryRequest request);
    Task<Result> DeleteAsync(long id);
}
