using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace NiRepository.Context
{
    public class NixContext : DbContext
    {
        public NixContext(DbContextOptions<NixContext> options) : base(options)
        {
        }

        public DbSet<Client> ClientAccounts;
        public DbSet<DebtAccount> DebtStatements;
        public DbSet<CreditAccount> CreditAccount;
    }
}
