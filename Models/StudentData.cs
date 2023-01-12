namespace Andronic_Paul_Proiect.Models
{
    public class StudentData
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Exam> Exams { get; set; }
        public IEnumerable<StudentExam> StudentExams { get; set; }
    }
}
