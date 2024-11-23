namespace E_LearningPlatform.Models
{
    public class Professor : User
    {
        public string Degree { get; set; }  // Highest academic degree (e.g., PhD, Master's)
        public string FieldOfExpertise { get; set; }  // Area of teaching expertise (e.g., Mathematics, Computer Science)
        public int YearsOfExperience { get; set; }  // Years of teaching experience
        public string PhoneNumber { get; set; } 
        public ICollection<Course> CreatedCourses { get; set; }
    }
}
