using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolExample.Data;

namespace SchoolExample.Models
{
    public class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (!context.Courses.Any())
            {
                List<Course> newCourses = new List<Course>()
                {
                    new Course { Title = "Intro to Seed Methods" },
                    new Course { Title = "Advanced Seed Methods"},
                    new Course {Title = "Physics for Poets"}
                };
                context.Courses.AddRange(newCourses);
            }

            if (!context.Roles.Any())
            {
                List<string> newRoles = new List<string>()
                {
                    "Administrator",
                    "Instructor",
                    "Student"
                };

                foreach(string role in newRoles)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            if(!context.Users.Any())
            {
                var passwordHasher = new PasswordHasher<ApplicationUser>();

                // New ADMIN
                ApplicationUser firstAdmin = new ApplicationUser
                {
                    Email = "admin1@mitt.ca",
                    NormalizedEmail = "ADMIN1@MITT.CA",
                    UserName = "admin1@mitt.ca",
                    NormalizedUserName = "ADMIN1@MITT.CA",
                    EmailConfirmed = true
                };

                var hashedPassword = passwordHasher.HashPassword(firstAdmin, "P@ssword1");
                firstAdmin.PasswordHash = hashedPassword;

                await userManager.CreateAsync(firstAdmin);
                await userManager.AddToRoleAsync(firstAdmin, "Administrator");

                // New STUDENT
                ApplicationUser seedStudent = new ApplicationUser
                {
                    Email = "billy.Talent@mitt.ca",
                    NormalizedEmail = "BILLY.TALENT@MITT.CA",
                    UserName = "billy.Talent@mitt.ca",
                    NormalizedUserName = "BILLY.TALENT@MITT.CA",
                    EmailConfirmed = true
                };

                hashedPassword = passwordHasher.HashPassword(seedStudent, "P@ssword1");
                seedStudent.PasswordHash = hashedPassword;

                await userManager.CreateAsync(seedStudent);

                seedStudent.StudentRecord = new StudentRecord {
                    User = seedStudent,
                    UserId = seedStudent.Id,
                    Notes = "Made some pop punk albums in the mid 00's",
                    IsDomestic = false,
                    TotalHours = 300
                };

                await userManager.UpdateAsync(seedStudent);
            }

            context.SaveChanges();
        }
    }
}
