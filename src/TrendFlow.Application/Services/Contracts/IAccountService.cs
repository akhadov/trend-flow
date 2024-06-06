using TrendFlow.Application.Models.Accounts;

namespace TrendFlow.Application.Services.Contracts;

public interface IAccountService
{
    Task<string> LogInAsync(AccountLoginRequest accountLogin);

    Task<bool> RegisterAsync(AccountCreateRequest accountCreate);

    Task<bool> VerifyEmailAsync(VerifyEmailRequest verifyEmail);

    Task SendCodeAsync(SendToEmailRequest sendToEmail);

    Task<bool> VerifyPasswordAsync(UserResetPasswordRequest userResetPassword);
}
