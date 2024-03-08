using MimeKit;
using System.Net.Mail;
using System.Net;

namespace HalloDoc.Utility
{
    public static class EmailSender
    {
        public static Task SendEmailAsync(string email, string subject, string message)
        {
            var emailToSend = new MimeMessage();
            emailToSend.From.Add(MailboxAddress.Parse("vijay.aniyaliya@etatvasoft.com"));
            emailToSend.To.Add(MailboxAddress.Parse(email));
            emailToSend.Subject = subject;
            emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message };
            //emailToSend.Attachments


            using (var emailClient = new MailKit.Net.Smtp.SmtpClient())
            {
                emailClient.Connect("mail.etatvasoft.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                emailClient.Authenticate("vijay.aniyaliya@etatvasoft.com", "4{6#0Ontg8fi");
                emailClient.Send(emailToSend);
                emailClient.Disconnect(true);
                return Task.CompletedTask;
            }
        }

        public static async Task SendMailOnGmail(string Toemail, string subject, string message, List<string> Attachments, string uploads)
        {
            try
            {
                var email = "tatva.dotnet.vijayaniyaliya@outlook.com";
                var Password = "Vijay010803";

                var client = new SmtpClient("smtp.office365.com", 587)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(email, Password)
                };

                var mailContent = new MailMessage
                {
                    From = new MailAddress(email)
,
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true,
                };

                mailContent.To.Add(Toemail);

                foreach (var attachmentPath in Attachments)
                {
                    string Filepath = Path.Combine(uploads, attachmentPath);
                    if (!string.IsNullOrEmpty(Filepath))
                    {
                        var attachment = new Attachment(Filepath);
                        mailContent.Attachments.Add(attachment);
                    }
                }

                await client.SendMailAsync(mailContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
