using Aplication.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistency;

namespace Aplication.Repository
{
    // Repository class for handling users, inheriting from the GenericRepository<User> class and implementing IUserRepository interface
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        // Private field to store the instance of ApiDbContext
        private readonly ApiDbContext _context;

        // Constructor to initialize the repository with a ApiDbContext
        public UserRepository(ApiDbContext context) : base(context)
        {
            _context = context;
        }

        // Method to retrieve a user by their refresh token asynchronously
        public async Task<User> GetByRefreshTokenAsync(string refreshToken)
        {
            // Retrieve a user by their refresh token and include related Roles and RefreshTokens
            return await _context.Users
                .Include(u => u.Roles)
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
        }

        // Method to retrieve a user by their username asynchronously
        public async Task<User> GetByUsernameAsync(string username)
        {
            // Retrieve a user by their username and include related Roles and RefreshTokens
            return await _context.Users
                .Include(u => u.Roles)
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }
    }
}
