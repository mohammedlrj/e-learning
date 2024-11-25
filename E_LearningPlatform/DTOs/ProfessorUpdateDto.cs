namespace E_LearningPlatform.DTOs
{
    public class ProfessorUpdateDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string CIN { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Degree { get; set; }
        public string FieldOfExpertise { get; set; }
        public int YearsOfExperience { get; set; }
        public string PhoneNumber { get; set; }
    }
}
