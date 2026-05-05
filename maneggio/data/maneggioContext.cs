using maneggio.models;
using Microsoft.EntityFrameworkCore;
namespace maneggio.data
{
    public class maneggioContext : DbContext
    {
        public maneggioContext(DbContextOptions<maneggioContext> options) :base(options) { }
        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Prenotazione> Prenotazioni { get; set; }
    }
}
