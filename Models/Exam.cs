using System.ComponentModel.DataAnnotations;

namespace Andronic_Paul_Proiect.Models
{
    public class Exam
    {
        public int ID { get; set; }
        [Required, StringLength(50, MinimumLength = 2)]
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public string TeacherName { get; set; }
        public ICollection<StudentExam> ?StudentExam { get; set; }
    }
}
