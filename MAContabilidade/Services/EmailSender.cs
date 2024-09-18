using System.Net;
using System.Net.Mail;

namespace MAContabilidade.Services;

public class EmailSender : IEmailSender
{
    public async Task SendEmailAsync(string emailAdress, string subject, string htmlMessage)
    {
        var mail = "ampmcontabilidade@outlook.com";
        var pw = "@AMContabilidade123";

        var client = new SmtpClient("smtp-mail.outlook.com", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(mail, pw)
        };

        MailMessage sendMail = new(
            from: mail,
            to: emailAdress,
            subject,
            htmlMessage
        );
        sendMail.IsBodyHtml = true;

        await client.SendMailAsync(sendMail);
    }
}