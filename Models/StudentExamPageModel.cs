using Microsoft.AspNetCore.Mvc.RazorPages;
using Andronic_Paul_Proiect;
using Andronic_Paul_Proiect.Data;
namespace Andronic_Paul_Proiect.Models
{
    public class StudentExamPageModel : PageModel
    {
        public List<AssignedExamData> AssignedExamDataList;
        public void PopulateAssignedExamData(Andronic_Paul_ProiectContext context,Student student)
        {
            var stu1 = student;
            var stu2 = context;
            var allExams = context.Exam;
            var studentExams = new HashSet<int>(
            student.StudentExam.Select(c => c.ExamID)); 
            AssignedExamDataList = new List<AssignedExamData>();
            foreach (var exam in allExams)
            {
                AssignedExamDataList.Add(new AssignedExamData
                {
                    ExamID = exam.ID,
                    ExamName = exam.ExamName,
                    Assigned = studentExams.Contains(exam.ID)
                });
            }
        }
        public void UpdateStudentExams(Andronic_Paul_ProiectContext context, string[] selectedExams, Student studentToUpdate)
        {
            if (selectedExams == null)
            {
                studentToUpdate.StudentExam = new List<StudentExam>();
                return;
            }
            var selectedExamHS = new HashSet<string>(selectedExams);
            var studentExams = new HashSet<int> (studentToUpdate.StudentExam.Select(c => c.Exam.ID));
            foreach (var exam in context.Exam)
            {
                if (selectedExamHS.Contains(exam.ID.ToString()))
                {
                    if (!studentExams.Contains(exam.ID))
                    {
                        studentToUpdate.StudentExam.Add(
                        new StudentExam
                        {
                            StudentID = studentToUpdate.ID,
                            ExamID = exam.ID
                        });
                    }
                }
                else
                {
                    if (studentExams.Contains(exam.ID))
                    {
                        StudentExam examToRemove
                        = studentToUpdate
                        .StudentExam
                        .SingleOrDefault(i => i.ExamID == exam.ID);
                        context.Remove(examToRemove);
                    }
                }
            }
        }
    }

}