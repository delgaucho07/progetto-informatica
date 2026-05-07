using MimeKit;
using MailKit.Net.Smtp;

namespace Maneggio1.Services
{
    public class EmailService
    {
        public void InviaConfermaPrenotazione(string email, string data)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Maneggio", "test@email.com"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Conferma prenotazione";

            message.Body = new TextPart("plain")
            {
                Text = $"Prenotazione confermata per il giorno {data}"
            };

            using var client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("email", "password");
            client.Send(message);
            client.Disconnect(true);
        }
    }
}