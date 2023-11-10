using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Vocas.Models; // Make sure this is the correct namespace for your Word model

namespace Vocas.Data
{
    public class VocasContext : IdentityDbContext<User>
    {

        public VocasContext(DbContextOptions<VocasContext> options) : base(options)
        {
        }


        public DbSet<Word> Words { get; set; }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Word>().ToTable("Words");
            // Configure other entities and relationships here if necessary
        }
    }
}
