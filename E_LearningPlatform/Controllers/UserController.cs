using E_LearningPlatform.DTOs;
using E_LearningPlatform.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_LearningPlatform.Controllers
{

    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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

        [HttpGet("{email}")]
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
    }
}
