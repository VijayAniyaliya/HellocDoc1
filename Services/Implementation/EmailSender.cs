using MimeKit;
using Services.Contracts;

namespace HalloDoc.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var emailToSend = new MimeMessage();
            emailToSend.From.Add(MailboxAddress.Parse("vijay.aniyaliya@etatvasoft.com"));
            emailToSend.To.Add(MailboxAddress.Parse(email));
            emailToSend.Subject = subject;
            emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message };


            using (var emailClient = new MailKit.Net.Smtp.SmtpClient())
            {
                emailClient.Connect("mail.etatvasoft.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                emailClient.Authenticate("vijay.aniyaliya@etatvasoft.com", "4{6#0Ontg8fi"); 
                emailClient.Send(emailToSend);
                emailClient.Disconnect(true);
                return Task.CompletedTask;
            }
        }
    }
}
