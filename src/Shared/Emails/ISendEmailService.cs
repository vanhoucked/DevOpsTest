using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project.Shared.Emails
{
    public interface ISendEmailService
    {
        Task<bool> SendEmail(ContactDto.Detail contact);
    }
}
