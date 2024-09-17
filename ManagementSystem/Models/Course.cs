using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string CourseName { get; set; }

        public string TeacherName { get; set; }

        [ValidateNever]
        public List<Student> Students { get; set; }
    }
}
