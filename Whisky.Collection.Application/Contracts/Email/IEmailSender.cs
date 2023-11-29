using Whisky.Collection.Application.Models.Email;

namespace Whisky.Collection.Application.Contracts.Email;

public interface IEmailSender
{
    Task<bool> SendEmail(EmailMessage email);
}
