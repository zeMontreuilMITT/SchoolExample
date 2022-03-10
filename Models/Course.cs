namespace SchoolExample.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double AverageGrade { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }
    }
}
