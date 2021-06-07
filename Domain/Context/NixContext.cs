using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Microsoft.Extensions.Configuration;

namespace Domain.Context
{
    public class NixContext : DbContext
    {

        public NixContext() : base()
        {

        }

        public NixContext(DbContextOptions<NixContext> options) : base(options)
        {
        }

        // Adicionado para "contornar rapidamente" problema que tive para gerar migrations
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=NixApi;Trusted_Connection=True");
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<DebtAccount> DebtAccounts { get; set; }
        public DbSet<CreditAccount> CreditAccounts { get; set; }
    }
}
