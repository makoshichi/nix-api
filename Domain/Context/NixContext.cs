using Microsoft.EntityFrameworkCore;
using Domain.Models;
using System;

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
            try
            {
                //Get connection string from somewhere else
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=NixApi;Trusted_Connection=True");
            }
            catch (Exception e)
            {

            }
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<DebtAccount> DebtAccounts { get; set; }
        public DbSet<CreditAccount> CreditAccounts { get; set; }
    }
}
