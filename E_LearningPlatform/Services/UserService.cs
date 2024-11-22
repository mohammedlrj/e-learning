using E_LearningPlatform.DTOs;
using E_LearningPlatform.Models;
using E_LearningPlatform.Repositories;

namespace E_LearningPlatform.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterProfessorAsync(ProfessorRegistrationDto professorDto)
        {
            if (professorDto.Password != professorDto.ConfirmPassword)
                throw new Exception("Passwords do not match.");

            var existingUser = await _userRepository.GetUserByEmailAsync(professorDto.Email);
            if (existingUser != null)
                throw new Exception("Email is already registered.");

            var user = new User
            {
                FirstName = professorDto.FirstName,
                LastName = professorDto.LastName,
                Email = professorDto.Email,
                UserName = professorDto.FirstName + professorDto.LastName,
                RegistrationDate = DateTime.UtcNow,
                PasswordHash = professorDto.Password
            };

            await _userRepository.AddUserAsync(user, "Professor");
        }

        public async Task RegisterStudentAsync(StudentRegistrationDto studentDto)
        {
            if (studentDto.Password != studentDto.ConfirmPassword)
                throw new Exception("Passwords do not match.");

            var existingUser = await _userRepository.GetUserByEmailAsync(studentDto.Email);
            if (existingUser != null)
                throw new Exception("Email is already registered.");

            var user = new User
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Email = studentDto.Email,
                UserName = studentDto.FirstName + studentDto.LastName,
                RegistrationDate = DateTime.UtcNow,
                PasswordHash = studentDto.Password
            };

            await _userRepository.AddUserAsync(user, "Student");
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            return user;
        }
    }
}
