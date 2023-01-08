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
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        [Column(TypeName = "decimal(10, 0)")]
        public decimal PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
       
        public Faculty Faculty { get; set; }

    }
}
