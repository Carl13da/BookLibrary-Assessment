using BookLibrary.Data.Mappings;
using BookLibrary.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookLibrary.Data.Contexts
{
    public class SqlContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public SqlContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("LocalDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BookMap.Map(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
    }
}
