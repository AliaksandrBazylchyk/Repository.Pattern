using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repository.Pattern.Common.Options;
using Repository.Pattern.DAL.Entities;

namespace Repository.Pattern.DAL.Contexts
{
    public sealed class PostgresDbContext : DbContext
    {
        private readonly ConnectionStrings _connectionStrings;

        public DbSet<ExampleEntity> Examples { get; set; }

        public PostgresDbContext(
            IOptions<ConnectionStrings> connectionStrings
        )
        {
            _connectionStrings = connectionStrings.Value;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionStrings.PostgresConnection);
        }
    }
}