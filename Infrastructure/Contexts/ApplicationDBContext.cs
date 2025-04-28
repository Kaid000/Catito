using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        optionsBuilder.UseNpgsql("Host=localhost;Port=8410;Database=catito_database;Username=catito_user;Password=secret");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(b => b.Id);
            modelBuilder.Entity<User>().Property(b => b.Id).IsRequired();
            modelBuilder.Entity<User>().Property(b => b.Email).IsRequired();
            modelBuilder.Entity<User>().Property(b => b.PasswordHash).IsRequired();
            modelBuilder.Entity<User>().Property(b => b.CreatedAt).IsRequired().HasDefaultValue(DateTime.UtcNow);
            modelBuilder.Entity<User>().Property(b => b.UpdatedAt).IsRequired().HasDefaultValue(DateTime.UtcNow);

        }
    }
}
