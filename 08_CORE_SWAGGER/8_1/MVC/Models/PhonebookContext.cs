using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace MVC.Models
{
    public class PhonebookContext : DbContext
    {
        public PhonebookContext(DbContextOptions<PhonebookContext> options)
            : base(options)
        {
        }

        public DbSet<Record> Phonebooks { get; set; } = null!;
    }
}
