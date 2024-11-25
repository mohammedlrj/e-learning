using E_LearningPlatform.DTOs;
using E_LearningPlatform.Models;
using E_LearningPlatform.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E_LearningPlatform.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, UserManager<User> userManager, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task RegisterProfessorAsync(ProfessorRegistrationDto professorDto)
        {
            if (professorDto.Password != professorDto.ConfirmPassword)
                throw new Exception("Passwords do not match.");

            var existingUser = await _userRepository.GetUserByEmailAsync(professorDto.Email);
            if (existingUser != null)
                throw new Exception("Email is already registered.");

            var professor = new Professor
            {
                FirstName = professorDto.FirstName,
                LastName = professorDto.LastName,
                Email = professorDto.Email,
                Gender = professorDto.Gender,
                CIN = professorDto.CIN,
                ProfilePicture = professorDto.ProfilePicture,
                Degree = professorDto.Degree,
                FieldOfExpertise = professorDto.FieldOfExpertise,
                YearsOfExperience = professorDto.YearsOfExperience,
                PhoneNumber = professorDto.PhoneNumber,
                DateOfBirth = professorDto.DateOfBirth,
                UserName = professorDto.FirstName + professorDto.LastName,
                RegistrationDate = DateTime.UtcNow,
                PasswordHash = professorDto.Password
            };

            await _userRepository.AddUserAsync(professor, "Professor");
        }

        public async Task RegisterStudentAsync(StudentRegistrationDto studentDto)
        {
            if (studentDto.Password != studentDto.ConfirmPassword)
                throw new Exception("Passwords do not match.");

            var existingUser = await _userRepository.GetUserByEmailAsync(studentDto.Email);
            if (existingUser != null)
                throw new Exception("Email is already registered.");

            var student = new Student
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Email = studentDto.Email,
                Gender = studentDto.Gender,
                CIN = studentDto.CIN,
                ProfilePicture = studentDto.ProfilePicture,
                Major = studentDto.Major,
                Level = studentDto.Level,
                DateOfBirth = studentDto.DateOfBirth,
                UserName = studentDto.FirstName + studentDto.LastName,
                RegistrationDate = DateTime.UtcNow,
                PasswordHash = studentDto.Password
            };

            await _userRepository.AddUserAsync(student, "Student");
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return user;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            return user;
        }

        public async Task<bool> DeleteUserByIdAsync(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if(user == null)
            {
                return false;
            }

            return await _userRepository.DeleteByIdAsync(user);
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if(user == null)
            {
                return null;
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!isPasswordValid)
            {
                return null;
            }

            if (user.Status != Enums.Status.Approved)
            {
                return null;
            }

            var token = GenerateJwtToken(user);
            return token;
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("userId", user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Status.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IEnumerable<UserInfoDto>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync(); 
        }

        public async Task<User> UpdateStudentAsync(string id, StudentUpdateDto studentUpdateDto)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null || user is not Student)
                throw new KeyNotFoundException("Student not found or not authentified.");

            var student = (Student)user;

            student.UserName = $"{studentUpdateDto.FirstName}{studentUpdateDto.LastName}";
            student.Email = studentUpdateDto.Email;
            student.FirstName = studentUpdateDto.FirstName;
            student.LastName = studentUpdateDto.LastName;
            student.Gender = studentUpdateDto.Gender;
            student.CIN = studentUpdateDto.CIN;
            student.ProfilePicture = studentUpdateDto.ProfilePicture;
            student.DateOfBirth = studentUpdateDto.DateOfBirth != DateTime.MinValue ? studentUpdateDto.DateOfBirth : student.DateOfBirth;
            student.Major = studentUpdateDto.Major;
            student.Level = studentUpdateDto.Level;

            await _userRepository.UpdateUserAsync(student);
            return student;
        }

        public async Task<User> UpdateProfessorAsync(string id, ProfessorUpdateDto professorUpdateDto)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null || user is not Professor)
                throw new KeyNotFoundException("Professor not found or not authentified.");

            var professor = (Professor)user;

            professor.UserName = $"{professorUpdateDto.FirstName}{professorUpdateDto.LastName}";
            professor.Email = professorUpdateDto.Email;
            professor.FirstName = professorUpdateDto.FirstName;
            professor.LastName = professorUpdateDto.LastName;
            professor.Gender = professorUpdateDto.Gender;
            professor.CIN = professorUpdateDto.CIN;
            professor.ProfilePicture = professorUpdateDto.ProfilePicture;
            professor.DateOfBirth = professorUpdateDto.DateOfBirth != DateTime.MinValue ? professorUpdateDto.DateOfBirth : professor.DateOfBirth;
            professor.Degree = professorUpdateDto.Degree;
            professor.FieldOfExpertise = professorUpdateDto.FieldOfExpertise;
            professor.YearsOfExperience = professorUpdateDto.YearsOfExperience;
            professor.PhoneNumber = professorUpdateDto.PhoneNumber;

            await _userRepository.UpdateUserAsync(professor);
            return professor;
        }
    }
}
