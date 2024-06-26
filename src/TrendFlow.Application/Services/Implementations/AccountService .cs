﻿using Microsoft.Extensions.Caching.Memory;
using System.Net;
using TrendFlow.Application.Models.Accounts;
using TrendFlow.Application.Models.Email;
using TrendFlow.Application.Security;
using TrendFlow.Application.Services.Contracts;
using TrendFlow.Application.Services.Contracts.Auth;
using TrendFlow.Application.Services.Contracts.Email;
using TrendFlow.Application.Services.Contracts.File;
using TrendFlow.DataAccess.Data;
using TrendFlow.DataAccess.Repositories.Contracts;
using TrendFlow.Domain.Users;

namespace TrendFlow.Application.Services.Implementations;

public class AccountService : IAccountService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IAuthManager _authManager;
    private readonly IMemoryCache _cache;
    private readonly IEmailService _emailService;
    private readonly IFileService _fileService;

    public AccountService(IUnitOfWork unitOfWork, IUserRepository userRepository, IAuthManager authManager,
        IMemoryCache cache, IEmailService emailService, IFileService fileService)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _authManager = authManager;
        _cache = cache;
        _emailService = emailService;
        _fileService = fileService;
    }

    public async Task<string> LogInAsync(AccountLoginRequest accountLogin)
    {
        if (accountLogin.EmailOrUsername.Contains('@'))
        {
            var user = await _userRepository.GetByEmailAsync(accountLogin.EmailOrUsername.ToLower().Trim());

            //if (user is null) throw new StatusCodeException(HttpStatusCode.NotFound, message: "email is wrong");

            // if (user.EmailConfirmed is false)
            //   throw new StatusCodeException(HttpStatusCode.BadRequest, message: "email did not verified");

            if (PasswordHasher.Verify(accountLogin.Password, user.PasswordSalt, user.Password))
                return _authManager.GenerateToken(user);
            //else throw new StatusCodeException(HttpStatusCode.BadRequest, message: "password is wrong");
        }
        else
        {
            var user = await _userRepository.GetByUsernameAsync(accountLogin.EmailOrUsername);

            //if (user is null) throw new StatusCodeException(HttpStatusCode.NotFound, message: "username is wrong");

            //if (user.EmailConfirmed is false)
            //  throw new StatusCodeException(HttpStatusCode.BadRequest, message: "email did not verified");

            if (PasswordHasher.Verify(accountLogin.Password, user.PasswordSalt, user.Password))
                return _authManager.GenerateToken(user);
            //else throw new StatusCodeException(HttpStatusCode.BadRequest, message: "password is wrong");
        }

    }

    public async Task<bool> RegisterAsync(AccountCreateRequest accountCreate)
    {
        var user = await _userRepository.GetByEmailAsync(accountCreate.Email.ToLower());
        if (user is not null) throw new StatusCodeException(HttpStatusCode.BadRequest, message: "user already exist");

        var newUser = (User)accountCreate;
        var hashResult = PasswordHasher.Hash(accountCreate.Password);
        newUser.Salt = hashResult.Salt;
        newUser.PasswordHash = hashResult.Hash;
        newUser.ImagePath = $"{_fileService.ImageFolderName}/IMG_bf6218f9-dd17-44ce-8d39-e9b9d374a903.jpg";


        await _userRepository.CreateAsync(newUser);

        var email = new SendToEmailRequest();
        email.Email = accountCreate.Email;

        await SendCodeAsync(email);

        return true;
    }

    public async Task SendCodeAsync(SendToEmailRequest sendToEmail)
    {
        int code = new Random().Next(10000, 99999);

        _cache.Set(sendToEmail.Email, code, TimeSpan.FromMinutes(10));

        var message = new EmailMessage()
        {
            To = sendToEmail.Email,
            Subject = "Verifcation code",
            Body = code.ToString()
        };

        await _emailService.SendAsync(message);
    }

    public async Task<bool> VerifyEmailAsync(VerifyEmailRequest verifyEmail)
    {
        var user = await _userRepository.GetByEmailAsync(verifyEmail.Email);

        //if (user is null)
        //   throw new StatusCodeException(HttpStatusCode.NotFound, message: "User not found");

        //if (_cache.TryGetValue(verifyEmail.Email, out int expectedCode) is false)
        //  throw new StatusCodeException(HttpStatusCode.BadRequest, message: "Code is expired");

        // if (expectedCode != verifyEmail.Code)
        //   throw new StatusCodeException(HttpStatusCode.BadRequest, message: "Code is wrong");

        user.EmailConfirmed = true;
        await _userRepository.UpdateAsync(user.Id, user);
        return true;
    }

    public async Task<bool> VerifyPasswordAsync(UserResetPasswordRequest userResetPassword)
    {
        var user = await _userRepository.GetByEmailAsync(userResetPassword.Email);

        //if (user is null)
        //    throw new StatusCodeException(HttpStatusCode.NotFound, message: "User not found");

        //if (user.EmailConfirmed is false)
        //    throw new StatusCodeException(HttpStatusCode.BadRequest, message: "Email did not verified");

        var changedPassword = PasswordHasher.Hash(userResetPassword.Password, user.PasswordSalt);

        user.Password = changedPassword;

        await _userRepository.UpdateAsync(user.Id, user);

        return true;
    }
}