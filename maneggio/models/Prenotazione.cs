namespace maneggio.models
{
    public class Prenotazione
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public DateTime Data { get; set; }
        public int UtenteId { get; set; }
        public Utente Utente { get; set; }
    }
}
