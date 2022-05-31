using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _07_MVC_IDENTITY.Models
{
    public class DBContext : IdentityDbContext<User>
    {
        private string _connectionString = "DataSource=dict.db";

        public DBContext(DbContextOptions<DBContext> options) : base(options){}

        public DBContext(string v) => _connectionString = v;

        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(_connectionString);
    }
}
