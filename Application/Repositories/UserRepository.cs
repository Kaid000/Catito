using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
   public class UserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        // Get User by Credentials
        public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            var sql = @"
                SELECT * FROM ""Users""
                WHERE ""Email"" = {0}
                AND ""PasswordHash"" = crypt({1}, ""PasswordHash"")
                LIMIT 1
                ";

            return await _context.Users
                .FromSqlRaw(sql, email, password)
                .FirstOrDefaultAsync();
        }

    }
}
