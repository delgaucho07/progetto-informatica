using MimeKit;
using MailKit.Net.Smtp;

namespace Maneggio1.Services
{
    public class EmailService
    {
        public void InviaPrenotazione(
            string destinatario,
            string data,
            string attivita,
            string cavallo
        )
        {
            var email = new MimeMessage();

            email.From.Add(
                new MailboxAddress(
                    "Maneggio",
                    "tuaemail@gmail.com"
                )
            );

            email.To.Add(
                MailboxAddress.Parse(destinatario)
            );

            email.Subject = "Conferma Prenotazione";

            email.Body = new TextPart("plain")
            {
                Text =
$@"Ciao caro/a cliente,

la tua prenotazione è confermata.

Data e ora: {data}

Attività: {attivita}

Cavallo scelto: {cavallo}

Grazie per aver scelto il nostro maneggio."
            };

            using var smtp = new SmtpClient();

            smtp.Connect("smtp.gmail.com", 587, false);

            smtp.Authenticate(
                "maneggio.progetto@gmail.com",
                "atzi oalg qika bjah"
            );

            smtp.Send(email);

            smtp.Disconnect(true);
        }
    }
}