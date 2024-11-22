using E_LearningPlatform.Data;
using E_LearningPlatform.Models;
using Microsoft.AspNetCore.Identity;

namespace E_LearningPlatform.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public UserRepository(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task AddUserAsync(User user, string role)
        {
            var result = await _userManager.CreateAsync(user, user.PasswordHash);

            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);
            }
            else
            {
                throw new Exception(string.Join("; ", result.Errors.Select(e => e.Description)));
            }
        }
    }
}
