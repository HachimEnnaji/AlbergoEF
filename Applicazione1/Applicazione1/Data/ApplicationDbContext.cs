using Applicazione1.Models;
using Microsoft.EntityFrameworkCore;

namespace Applicazione1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<admin> admins { get; set; }

        public DbSet<Camera> Camera { get; set; }
        public DbSet<Pensione> Pensione { get; set; }
        public DbSet<Prenotazione> Prenotazione { get; set; }
        public DbSet<Servizio> Servizio { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

    }
}
