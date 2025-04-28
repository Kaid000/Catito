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
        public async Task<User> GetUserByEmailAndPasswordHashAsync(string email, string passwordHash)
        {
            return await _context.Users
                .FirstOrDefaultAsync(user => user.Email == email && user.PasswordHash == passwordHash);
        }
    }
}
