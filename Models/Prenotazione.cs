namespace Maneggio1.Models
{
    public class Prenotazione
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }

        public int IdUtente { get; set; }
        public Utenti Utente { get; set; }
    }
}
