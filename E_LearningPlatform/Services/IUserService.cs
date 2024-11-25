using E_LearningPlatform.DTOs;
using E_LearningPlatform.Models;

namespace E_LearningPlatform.Services
{
    public interface IUserService
    {
        Task RegisterProfessorAsync(ProfessorRegistrationDto professorDto);
        Task RegisterStudentAsync(StudentRegistrationDto studentDto);
        Task<User> GetUserByIdAsync(string id);
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> DeleteUserByIdAsync(string id);
        Task<string> LoginAsync(LoginDto loginDto);
        Task<IEnumerable<UserInfoDto>> GetAllUsersAsync();
        Task<User> UpdateStudentAsync(string id, StudentUpdateDto studentUpdateDto);
        Task<User> UpdateProfessorAsync(string id, ProfessorUpdateDto professorUpdateDto);
    }
}
