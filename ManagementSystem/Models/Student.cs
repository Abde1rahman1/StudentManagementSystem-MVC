using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ManagementSystem.Models
{
    public class Student
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a valid Full name!")]
        [MinLength(8, ErrorMessage = "Full Name can't be less than 8 Characters")]
        [MaxLength(50, ErrorMessage = "Full Name can't be more than 50 Characters")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Enter a valid National Id")]
        [MinLength(8, ErrorMessage = "NationalId can't be less than 14 Characters")]
        [MaxLength(50, ErrorMessage = "National Id can't be more than 14 Characters")]
        [Display(Name = "National Id")]
        public string NationalId { get; set; }


        [Required(ErrorMessage = "Enter a valid Grade!")]

        [DisplayName("Grade")]
        public string Grade { get; set; }


        public int GPA { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Enroll Date")]
        public DateTime EnrollDate { get; set; }
        [DataType(DataType.Date)]

        [DisplayName("GraduationDate")]
        public DateTime GraduationDate { get; set; }
        [DisplayName("Phone No.")]
        [RegularExpression("^01\\d{9}$", ErrorMessage = "Invalid Phone No.")]
        public string PhoneNumber { get; set; }
        [DisplayName("Email Address")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }
        [DisplayName("Confirm Email Address")]
        [NotMapped]
        [Compare("EmailAddress", ErrorMessage = "Email and Confirm Email not match.")]
        public string ConfirmEmailAddress { get; set; }




        [DisplayName("Course")]
        [Range(1, double.MaxValue, ErrorMessage = "Choose a valid Department")]
        public int CourseId { get; set; }
        [ValidateNever]
        public Course Course { get; set; }

        [ValidateNever]
        public string ImagePath { get; set; }
        [ValidateNever]
        [NotMapped]
        [DisplayName("Image")]
        public IFormFile ImageFile { get; set; }
    }
}
