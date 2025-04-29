using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Cat> Cats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=8410;Database=catito_database;Username=catito_user;Password=secret");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Cats)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<User>()
                .Property(u => u.UpdatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<Cat>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Cat>()
                .Property(c => c.Name)
                .IsRequired();

            modelBuilder.Entity<Cat>()
                .Property(c => c.CreatedAt)
                .HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<Cat>()
                .Property(c => c.UpdatedAt)
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}
