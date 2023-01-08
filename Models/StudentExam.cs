namespace Andronic_Paul_Proiect.Models
{
    public class StudentExam
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int ExamID { get; set; }
        public Exam Exam { get; set; }

    }
}
