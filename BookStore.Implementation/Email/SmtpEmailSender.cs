using BookStore.Application.Email;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BookStore.Implementation.Email
{

    public class SmtpEmailSender : IEmailSender
    {
        private readonly string _fromEmail;
        private readonly string _fromPassword;

        public SmtpEmailSender(string fromEmail, string fromPassword)
        {
            _fromEmail = fromEmail;
            _fromPassword = fromPassword;
        }

        public void Send(SendEmailDto dto)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_fromEmail, _fromPassword)
            };

            var message = new MailMessage(_fromEmail, dto.SendTo);
            message.Subject = dto.Subject;
            message.Body = dto.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }

    }
}
