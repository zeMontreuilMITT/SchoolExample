using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolExample.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Enrollment> Enrollments { get; set; }
        public StudentRecord? StudentRecord { get; set; }
        public ApplicationUser()
        {
            Enrollments = new HashSet<Enrollment>();
        }
    }
}
