using TrendFlow.Application.Models.Email;

namespace TrendFlow.Application.Services.Contracts.Email;

public interface IEmailService
{
    public Task SendAsync(EmailMessage message);
}