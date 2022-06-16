using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace EmailSender
{
    public class Sender
    {
        public string SenderEmail { get; set; }
        private string Password { get; init; }
        public MemoryStream Stream { get; }
        private HashSet<string> RecipientEmails { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string FileName { get; set; }
        public Sender(string Email, string Password, MemoryStream Stream, string FileName)
        {
            this.SenderEmail = Email;
            this.Password = Password;
            this.Stream = Stream;
            RecipientEmails = new HashSet<string>();
            this.FileName = FileName;
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
            mail.Attachments.Add(GetAttachment());

            return mail;
        }

        public Attachment GetAttachment()
        {
            Attachment attachment = new Attachment(Stream, FileName);
            attachment.ContentType = new System.Net.Mime.ContentType("text/plain");
            return attachment;
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

    }
}
