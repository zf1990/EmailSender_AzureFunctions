using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace EmailSender
{
    public class Sender
    {
        public string SenderEmail { get; set; }
        private string Password { get; init; }
        private HashSet<string> RecipientEmails { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string AttachmentFileName { get; set; } = string.Empty;
        public Sender(string Email, string Password)
        {
            this.SenderEmail = Email;
            this.Password = Password;
            RecipientEmails = new HashSet<string>();
        }


        public void AddRecipientEmail(string Email) =>
            RecipientEmails.Add(Email);

        public void AddRecipientEmail(ICollection<string> Emails)
        {
            foreach (string Email in Emails)
            {
                AddRecipientEmail(Email);
            }
        }

        public void SetMessage(string message) =>
            Message = message;

        public void SetSubject(string subject) =>
            Subject = subject;



        private MailMessage BuildMailMessage()
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(SenderEmail);
            foreach (var RecipientEmail in RecipientEmails)           
                mail.To.Add(new MailAddress(RecipientEmail));
            
            mail.Subject = Subject;
            mail.Body = Message;
            mail.IsBodyHtml = true;
            mail.Attachments.Add(new Attachment(AttachmentFileName));

            return mail;
        }

        public void Send()
        {
            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(SenderEmail, Password);
            client.EnableSsl = true;
            MailMessage message = BuildMailMessage();
            client.Send(message);
        }

        public void AddAttachment(string fileName) {
            AttachmentFileName = fileName;
        }

    }
}
