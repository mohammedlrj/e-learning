using E_LearningPlatform.Enums;

namespace E_LearningPlatform.DTOs
{
    public class StudentUpdateDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string CIN { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Major { get; set; }
        public string Level { get; set; }
    }
}
