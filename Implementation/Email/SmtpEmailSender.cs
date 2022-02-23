using Application.Email;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Implementation.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        private object emailFrom;
        private object emailPassword;

        public SmtpEmailSender(object emailFrom, object emailPassword)
        {
            this.emailFrom = emailFrom;
            this.emailPassword = emailPassword;
        }

        public void Sender(SendEmailDto dto)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("probaalex4@gmail.com", "pASP123456")
            };

            var message = new MailMessage("probaalex4@gmail.com", dto.SendTo);
            message.Subject = dto.Subject;
            message.Body = dto.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
