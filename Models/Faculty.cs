using System.ComponentModel.DataAnnotations;

namespace Andronic_Paul_Proiect.Models
{
    public class Faculty
    {
        public int ID { get; set; }
        [Required, StringLength(50, MinimumLength = 2)]
        public string FacultyName { get; set; }
        public ICollection<Student>? Student { get; set; } //navigation property
    }
}
