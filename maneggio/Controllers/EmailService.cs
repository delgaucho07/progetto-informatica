using MailKit.Net.Smtp;
using MimeKit; 

namespace maneggio.services
{
    public class EmailService
    {
        public void InviaConfermaPrenotazione(string email, string data)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Maneggio", "tuamail@gmail.com"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Conferma prenotazione lezione";

            message.Body = new TextPart("plain")
            {
                Text = $"La tua prenotazione del {data} è stata confermata!"
            };

            using var client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);

            client.Authenticate("tuamail@gmail.com", "PASSWORD_APP");

            client.Send(message);
            client.Disconnect(true);
        }
    }
}
