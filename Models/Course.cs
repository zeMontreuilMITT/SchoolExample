using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolExample.Models
{
    public class Course
    {
        public int Id { get; set; }
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Name must be at least 3 characters and fewer than 200 characters long")]
        public string Title { get; set; }

        [Range(0, 100, ErrorMessage = "Values may be 0 to 100 only")]
        [Display(Name = "Average Grade")]
        public double? AverageGrade { get; set; }
        [NotMapped]
        public string? Tempdata { get; set; }
        public CourseInfo CourseInfo { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }
    }
        
    [ComplexType]
    public class CourseInfo
    {
        public string? InternationalDescription { get; set; }
        public string? DomesticDescription { get; set; }
        public string? CourseIntroduction { get; set; }
    }
}
