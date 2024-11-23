using E_LearningPlatform.Enums;
using Microsoft.AspNetCore.Identity;

namespace E_LearningPlatform.Models
{
    public class User : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string CIN { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; } 
        public Status Status { get; set; }
    }
}
