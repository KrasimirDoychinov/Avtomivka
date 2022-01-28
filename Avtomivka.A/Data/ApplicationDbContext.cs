
using Avtomivka.A.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Avtomivka.A.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext([NotNull] DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Log> Logs { get; set; }

        public DbSet<Models.Program> Programs { get; set; }

        public DbSet<WashReservation> WashReservations { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<Colon> Colons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Avtomivka;Integrated Security=true;");
            }

            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
