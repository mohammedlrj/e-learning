namespace E_LearningPlatform.Models
{
    public class Student : User
    {
        public string Major { get; set; } // (Computer Science)
        public string Level { get; set; } // (Undergraduate, Graduate)
        public ICollection<Course> EnrolledCourses { get; set; }
    }
}
