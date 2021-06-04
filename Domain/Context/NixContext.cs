using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Domain.Context
{
    public class NixContext : DbContext
    {
        public NixContext(DbContextOptions<NixContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<DebtAccount> DebtAccounts { get; set; }
        public DbSet<CreditAccount> CreditAccounts { get; set; }
    }
}
