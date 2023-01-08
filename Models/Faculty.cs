namespace Andronic_Paul_Proiect.Models
{
    public class Faculty
    {
        public int ID { get; set; }
        public string FacultyName { get; set; }
        public ICollection<Student>? Student { get; set; } //navigation property
    }
}
