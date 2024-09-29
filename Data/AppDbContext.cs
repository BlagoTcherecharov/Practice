using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bank_account.Data
{
    internal class AppDbContext : DbContext
    {
        public IConfiguration _config { get; set; }

        public AppDbContext() { }

        public AppDbContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("DB_CONNECTION");
        }

        public DbSet<Account> Accounts { get; set; }
    }
}

