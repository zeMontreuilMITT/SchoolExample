using System.ComponentModel.DataAnnotations;

namespace SchoolExample.Models
{
    public class StudentRecord
    {
        public int Id { get; set; }
        [StringLength(500, MinimumLength = 3)]
        public string? Notes { get; set; }
        [Range(0, 999)]
        public int TotalHours { get; set; } = 0;
        public bool IsDomestic { get; set; }
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
