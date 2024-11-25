using E_LearningPlatform.DTOs;
using E_LearningPlatform.Models;

namespace E_LearningPlatform.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(string id);
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> DeleteByIdAsync(User user);
        Task AddUserAsync(User user, string role);
        Task<IEnumerable<UserInfoDto>> GetAllUsersAsync();
        Task<bool> UpdateUserAsync(User user);
    }
}
