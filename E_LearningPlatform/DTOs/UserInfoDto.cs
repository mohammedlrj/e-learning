namespace E_LearningPlatform.DTOs
{
    public class UserInfoDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string CIN { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }

        // Properties specific to Professor
        public string Degree { get; set; }
        public string FieldOfExpertise { get; set; }
        public int? YearsOfExperience { get; set; }
        public string PhoneNumber { get; set; }

        // Properties specific to Student
        public string Major { get; set; }
        public string Level { get; set; }

        // Relationship properties
        //public ICollection<string> CreatedCourses { get; set; } 
        //public ICollection<string> EnrolledCourses { get; set; }
    }
}
