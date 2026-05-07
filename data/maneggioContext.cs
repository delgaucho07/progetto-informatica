using Microsoft.EntityFrameworkCore;
using Maneggio1.Models;
namespace Maneggio1.data
{
    public class maneggioContext : DbContext
    {
        public maneggioContext(DbContextOptions<maneggioContext> options)
            : base(options)
        {
        }

        public DbSet<Utenti> Utenti { get; set; }
        public DbSet<Prenotazione> Prenotazioni { get; set; }
    }

}

