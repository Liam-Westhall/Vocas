using Microsoft.EntityFrameworkCore;
using Vocas.Models; // Make sure to use the correct namespace for your models

namespace Vocas.Data
{
    public class VocasContext : DbContext
    {
        public VocasContext(DbContextOptions<VocasContext> options) : base(options)
        {
        }

        public DbSet<Word> Words { get; set; }

        // If you have other entities, they would be included here as well, for example:
        // public DbSet<AnotherEntity> AnotherEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>().ToTable("Word");
            // Configure other entities and relationships here if necessary
        }
    }
}
