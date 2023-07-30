using CA.Application.CommonModels;
using CA.Application.Contracts.Infrastructure;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructrue.Mail
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSetting _emailSetting;

        public EmailSender(IOptions<EmailSetting> emailSetting)
        {
            _emailSetting = emailSetting.Value;
        }

        public async Task<bool> SendEmailAsync(Email email)
        {
            var client = new SendGridClient(_emailSetting.APIKey);
            // EmailAddress baraye package sendgrid ast
            var to = new EmailAddress(email.To);
            var from = new EmailAddress {

                Email = _emailSetting.FromAddress,
                Name = _emailSetting.FromName
            };
            // MailHelper baraye package sendgrid ast
            var messsage = MailHelper.CreateSingleEmail(from, to, email.subject, email.body, email.body);
            var response = await client.SendEmailAsync(messsage);

            return response.StatusCode == System.Net.HttpStatusCode.OK || 
                response.StatusCode == System.Net.HttpStatusCode.Accepted;
        }
    }
}
