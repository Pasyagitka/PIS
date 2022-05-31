using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace _8_1.Models
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
