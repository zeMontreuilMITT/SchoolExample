using Microsoft.AspNetCore.Identity;

namespace SchoolExample.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Enrollment> Enrollments { get; set; }

        public ApplicationUser()
        {
            Enrollments = new HashSet<Enrollment>();
        }
    }
}
