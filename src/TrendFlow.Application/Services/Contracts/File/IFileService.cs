using Microsoft.AspNetCore.Http;

namespace TrendFlow.Application.Services.Contracts.File;

public interface IFileService
{
    // returns sub path of this image
    public Task<string> UploadImageAsync(IFormFile image);

    public Task<bool> DeleteImageAsync(string subpath);

    // returns sub path of this avatar
    public Task<string> UploadAvatarAsync(IFormFile avatar);

    public Task<bool> DeleteAvatarAsync(string subpath);
}