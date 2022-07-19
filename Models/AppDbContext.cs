using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<General> General { get; set; }
        public DbSet<Unite> Unites { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Fournisseur> fournisseurs { get; set; }
        public DbSet<Paiement> paiements { get; set; }

        public DbSet<Famille> familles { get; set; }
    }
}
