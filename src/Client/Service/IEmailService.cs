using Project.Shared.Emails;

namespace Project.Client.Service

{
    public interface IEmailService
    {
        Task<bool> SendEmail(ContactDto.Detail contactForm);
    }
}
