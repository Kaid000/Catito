using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Contexts
{
    public class ApplicationDBContextFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
    {
        public ApplicationDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=8410;Database=catito_database;Username=catito_user;Password=secret");

            return new ApplicationDBContext(optionsBuilder.Options);
        }
    }
}
