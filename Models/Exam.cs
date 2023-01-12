namespace Andronic_Paul_Proiect.Models
{
    public class Exam
    {
        public int ID { get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public string TeacherName { get; set; }
        public ICollection<StudentExam> ?StudentExam { get; set; }
    }
}
