using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using SenderEmail.WebApi.Models;

namespace SenderEmail.WebApi.Services
{
    public class EmailService : IEmailService
    {
        public string Send(Email email)
        {
            var message = new MimeMessage();

            message.From.Add(MailboxAddress.Parse("iliana.mann78@ethereal.email"));
            message.To.Add(MailboxAddress.Parse(email.To));
            message.Subject = email.Subject;
            message.Body = new TextPart(TextFormat.Html) { Text = email.Body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("iliana.mann78@ethereal.email", "82YEU1mz6Bq3VVFBcB");
            var result = smtp.Send(message);

            //// create an image attachment for the file located at path
            //var attachment = new MimePart("image", "gif")
            //{
            //    Content = new MimeContent(File.OpenRead("path"), ContentEncoding.Default),
            //    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
            //    ContentTransferEncoding = ContentEncoding.Base64,
            //    FileName = Path.GetFileName("path")
            //};

            //// now create the multipart/mixed container to hold the message text and the
            //// image attachment
            //var multipart = new Multipart("mixed");
            //multipart.Add(body);
            //multipart.Add(attachment);

            // now set the multipart/mixed as the message body
            //message.Body = multipart;

            smtp.Disconnect(true);

            return result;
        }
    }
}
