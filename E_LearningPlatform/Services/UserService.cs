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

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            return user;
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
    }
}
