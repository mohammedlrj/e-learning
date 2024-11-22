using E_LearningPlatform.Models;

namespace E_LearningPlatform.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user, string role);
    }
}
