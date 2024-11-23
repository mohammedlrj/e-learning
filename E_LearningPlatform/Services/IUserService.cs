using E_LearningPlatform.DTOs;
using E_LearningPlatform.Models;

namespace E_LearningPlatform.Services
{
    public interface IUserService
    {
        Task RegisterProfessorAsync(ProfessorRegistrationDto professorDto);
        Task RegisterStudentAsync(StudentRegistrationDto studentDto);
        Task<User> GetUserByEmailAsync(string email);
        Task<string> LoginAsync(LoginDto loginDto);
    }
}
