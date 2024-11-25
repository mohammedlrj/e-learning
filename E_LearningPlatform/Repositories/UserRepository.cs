using E_LearningPlatform.Data;
using E_LearningPlatform.DTOs;
using E_LearningPlatform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> DeleteByIdAsync(User user)
        {
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
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

        public async Task<IEnumerable<UserInfoDto>> GetAllUsersAsync()
        {
            var users = _userManager.Users.ToList();
            var userDtos = new List<UserInfoDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault();

                if (role == "Admin") continue;

                UserInfoDto userInfoDto = new UserInfoDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Gender = user.Gender,
                    CIN = user.CIN,
                    ProfilePicture = user.ProfilePicture,
                    DateOfBirth = user.DateOfBirth,
                    RegistrationDate = user.RegistrationDate,
                    Status = user.Status.ToString(),
                    Role = role
                };

                if (user is Professor professor)
                {
                    userInfoDto.Degree = professor.Degree;
                    userInfoDto.FieldOfExpertise = professor.FieldOfExpertise;
                    userInfoDto.YearsOfExperience = professor.YearsOfExperience;
                    userInfoDto.PhoneNumber = professor.PhoneNumber;
                }
                else if (user is Student student)
                {
                    userInfoDto.Major = student.Major;
                    userInfoDto.Level = student.Level;
                }

                userDtos.Add(userInfoDto);
            }
            return userDtos;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
    }
}
