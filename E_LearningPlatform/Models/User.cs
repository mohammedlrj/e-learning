using E_LearningPlatform.Enums;
using Microsoft.AspNetCore.Identity;

namespace E_LearningPlatform.Models
{
    public class User : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }  
        public DateTime RegistrationDate { get; set; } 
        public Status Status { get; set; }
    }
}
