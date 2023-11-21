using Azure;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Project.Shared.Emails;


namespace Project.Services.Email
{
    public class SendEmailService : ISendEmailService
    {
        private readonly ISendGridClient _sendGridClient;

        public SendEmailService(ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient ?? throw new ArgumentNullException(nameof(sendGridClient));
        }

        public async Task<bool> SendEmail(ContactDto.Detail contact)
        {
            SendGridMessage msg = new SendGridMessage();
            EmailAddress from = new EmailAddress(contact.Email, contact.Naam);
            List<EmailAddress> recipients = new List<EmailAddress> { new EmailAddress("Gillesvancleemput1@gmail.com", "die haste") };
            msg.SetSubject("A new user has registered");
            msg.SetFrom(from);
            msg.AddTos(recipients);
            msg.PlainTextContent = contact.Message;

            SendGrid.Response response = await _sendGridClient.SendEmailAsync(msg);
            if (Convert.ToInt32(response.StatusCode) >= 400)
            {
                return false;
            }
            return true;
        }

    }
}
