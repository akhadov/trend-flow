using System.Net;
using TrendFlow.Application.Models.Users;
using TrendFlow.Application.Services.Contracts;
using TrendFlow.Application.Services.Contracts.File;
using TrendFlow.DataAccess.Data;
using TrendFlow.DataAccess.Repositories.Contracts;
using TrendFlow.Domain.Users;

namespace TrendFlow.Application.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IFileService _fileService;

    public UserService(IUnitOfWork unitOfWork, IFileService fileService, IUserRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _fileService = fileService;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var result = await _userRepository.GetByIdAsync(id);

        //if (result is null)
        //    throw new StatusCodeException(HttpStatusCode.NotFound, message: "User don't exist");

        //if (result.Role == UserRole.SuperAdmin)
        //    throw new StatusCodeException(HttpStatusCode.BadRequest, message: "You can't delete this user");

        var user = await _userRepository.RemoveAsync(id);

        return user != null;
    }

    public async Task<IEnumerable<UserResponse>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();

        return user;
    }

    public async Task<UserResponse> GetUsernameAsync(string username)
    {
        var user = await _userRepository.GetByUsernameAsync(username.Trim());

        //if (user is null)
        //    throw new StatusCodeException(HttpStatusCode.NotFound, message: "User not found");

        var userView = (UserViewModel)user;

        return userView;
    }

    public async Task<UserResponse> GetIdAsync(long id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        //if (user is null)
        //    throw new StatusCodeException(HttpStatusCode.NotFound, message: "User not found");

        //var userView = (UserViewModel)user;

        return userView;
    }


    public async Task<bool> UpdateAsync(long id, UserUpdateRequest viewModel)
    {
        var user = await _userRepository.GetByIdAsync(id);
        var userName = await _userRepository.GetByUsernameAsync(viewModel.Username.Trim());

        if (user is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, message: "User not found");

        if (userName is not null && userName.Username != user.Username)
            throw new StatusCodeException(HttpStatusCode.BadRequest, message: "This username already exist");

        if (phoneNumber is not null && phoneNumber.PhoneNumber != user.PhoneNumber)
            throw new StatusCodeException(HttpStatusCode.BadRequest, message: "This phoneNumber already exist");

        var newUser = (User)viewModel;
        newUser.Id = id;
        newUser.UpdatedAt = TimeHelper.GetCurrentDateTime();
        newUser.ImagePath = user.ImagePath;
        newUser.PasswordHash = user.PasswordHash;
        newUser.Salt = user.Salt;
        newUser.Email = user.Email;
        newUser.ContestCoins = user.ContestCoins;
        newUser.Role = user.Role;
        newUser.ProblemSetCoins = user.ProblemSetCoins;
        newUser.EmailConfirmed = user.EmailConfirmed;
        newUser.CreatedAt = user.CreatedAt;

        await _userRepository.UpdateAsync(id, newUser);

        return true;
    }

    public async Task<bool> RoleControlAsync(long userId, ushort roleNum)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, message: "User not found");

        if (roleNum >= 2)
            throw new StatusCodeException(HttpStatusCode.BadRequest, message: "This role don't exist");

        user.Role = (UserRole)roleNum;
        await _userRepository.UpdateAsync(userId, user);

        return true;
    }
}