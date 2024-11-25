using E_LearningPlatform.DTOs;
using E_LearningPlatform.Models;
using E_LearningPlatform.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_LearningPlatform.Controllers
{

    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public UserController(IUserService userService, UserManager<User> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpPost("professor")]
        public async Task<IActionResult> RegisterProfessor([FromBody] ProfessorRegistrationDto professorDto)
        {
            if (professorDto == null)
                return BadRequest("Student data is required.");

            try
            {
                await _userService.RegisterProfessorAsync(professorDto);
                return CreatedAtAction(nameof(GetByEmail), new { email = professorDto.Email }, null);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("student")]
        public async Task<IActionResult> RegisterStudent([FromBody] StudentRegistrationDto studentDto)
        {
            if (studentDto == null)
                return BadRequest("Student data is required.");

            try
            {
                await _userService.RegisterStudentAsync(studentDto);
                return CreatedAtAction(nameof(GetByEmail), new { email = studentDto.Email }, null);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] LoginDto loginDto)
        {
            var token = await _userService.LoginAsync(loginDto);
            if (token == null)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok(new { Token = token });
        }

        [HttpGet("by-id/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if(user == null)
                {
                    return NotFound(new { message = "User not found" });
                }
                return Ok(user);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("by-email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            try
            {
                var user = await _userService.GetUserByEmailAsync(email);
                if (user == null)
                    return NotFound(new { message = "User not found." });

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }
        }

        [HttpPut("student")]
        public async Task<IActionResult> UpdateStudent([FromBody] StudentUpdateDto studentUpdateDto)
        {
            if (studentUpdateDto == null)
            {
                return BadRequest("Invalid student data.");
            }

            try
            {
                var userId = User.FindFirstValue("userId");

                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("Token is missing or invalid");
                }

                var updatedStudent = await _userService.UpdateStudentAsync(userId, studentUpdateDto);

                return Ok(updatedStudent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("professor")]
        public async Task<IActionResult> UpdateProfessor([FromBody] ProfessorUpdateDto professorUpdateDto)
        {
            if (professorUpdateDto == null)
            {
                return BadRequest("Invalid professor data.");
            }

            try
            {
                var userId = User.FindFirstValue("userId");

                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("Token is missing or invalid");
                }

                var updatedProfessor = await _userService.UpdateProfessorAsync(userId, professorUpdateDto);

                return Ok(updatedProfessor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var result = await _userService.DeleteUserByIdAsync(id);
                if (!result)
                {
                    return NotFound(new { message = "User not found" });
                }

                return Ok(new { message = "User deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
