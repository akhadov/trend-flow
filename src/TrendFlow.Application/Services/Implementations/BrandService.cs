using Ardalis.GuardClauses;
using TrendFlow.Application.Models.Brands;
using TrendFlow.Application.Services.Contracts;
using TrendFlow.DataAccess.Data;
using TrendFlow.DataAccess.Repositories.Contracts;
using TrendFlow.Domain.Brands;
using TrendFlow.Domain.Common.Results;

namespace TrendFlow.Application.Services.Implementations;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BrandService(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
    {
        _brandRepository = Guard.Against.Null(brandRepository, nameof(brandRepository));
        _unitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
    }

    public async Task<Result<IEnumerable<BrandResponse>>> GetAllAsync()
    {
        var brands = await _brandRepository.GetAllAsync();
        var brandResponses = brands.Select(b => new BrandResponse(b.Id, b.Name, b.Description, b.ImagePath));
        return Result<IEnumerable<BrandResponse>>.Success(brandResponses);
    }

    public async Task<Result<BrandResponse>> GetByIdAsync(long id)
    {
        var brand = await _brandRepository.GetByIdAsync(id);
        if (brand is null)
        {
            throw new Exception("Brand not found");
        }

        var brandResponse = new BrandResponse(brand.Id, brand.Name, brand.Description, brand.ImagePath);
        return Result<BrandResponse>.Success(brandResponse);
    }

    public async Task<Result<BrandResponse>> CreateAsync(CreateBrandRequest request)
    {
        Guard.Against.Null(request, nameof(request));

        var brand = new Brand(request.Name, request.Description, request.ImagePath);
        await _brandRepository.AddAsync(brand);
        await _unitOfWork.SaveChangesAsync();

        var brandResponse = new BrandResponse(brand.Id, brand.Name, brand.Description, brand.ImagePath);
        return Result<BrandResponse>.Success(brandResponse);
    }

    public async Task<Result> UpdateAsync(long id, CreateBrandRequest request)
    {
        Guard.Against.Null(request, nameof(request));

        var brand = await _brandRepository.GetByIdAsync(id);
        if (brand is null)
        {
            return Result.Failure(BrandErrors.NotFound(id));
        }

        brand.Update(request.Name, request.Description, request.ImagePath);
        await _brandRepository.UpdateAsync(brand);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result> DeleteAsync(long id)
    {
        var brand = await _brandRepository.GetByIdAsync(id);
        if (brand is null)
        {
            return Result.Failure(BrandErrors.NotFound(id));
        }

        await _brandRepository.RemoveAsync(brand);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}