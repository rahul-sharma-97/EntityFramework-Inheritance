using EntityFrameworkInheritance.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkInheritance.Infrastructure
{
    internal class AnimalContext : DbContext
    {
        public AnimalContext(DbContextOptions<AnimalContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            // Use Below code to Implement TPT inheritance
            //modelBuilder.Entity<Dog>().ToTable("Dogs");
            //modelBuilder.Entity<Cat>().ToTable("Cats");
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Cat> Cats { get; set; }
    }
}
