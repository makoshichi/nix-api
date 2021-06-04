using Microsoft.EntityFrameworkCore;
using Domain.Models;
using System;

namespace Domain.Context
{
    public class NixContext : DbContext
    {

        public NixContext(DbContextOptions<NixContext> options) : base(options)
        {
        }
        //Comment above for migrations

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
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
