using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendFlow.Application.Models.Categories;
using TrendFlow.Application.Services.Contracts;
using TrendFlow.Domain.Common.Results;

namespace TrendFlow.Application.Services.Implementations;

public class CategoryService : ICategoryService
{
    public Task<Result<CategoryResponse>> CreateAsync(CreateCategoryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<IEnumerable<CategoryResponse>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Result<CategoryResponse>> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Result> UpdateAsync(long id, UpdateCategoryRequest request)
    {
        throw new NotImplementedException();
    }
}
