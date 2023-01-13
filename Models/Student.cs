using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Xml.Linq;

namespace Andronic_Paul_Proiect.Models
{
    public class Student
    {
        [Display(Name = "Student ID")]
        public int ID { get; set; }

        [Required, StringLength(50, MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(50, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, StringLength(50, MinimumLength = 2)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Phone Number")]
        public int PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public int FacultyID { get; set; }
        public Faculty ?Faculty { get; set; }
        public ICollection<StudentExam> ?StudentExam { get; set; }
    }
}
