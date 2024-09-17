using ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.DbContexts
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
