using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Andronic_Paul_Proiect.Data;
using Andronic_Paul_Proiect.Models;

namespace Andronic_Paul_Proiect.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly Andronic_Paul_Proiect.Data.Andronic_Paul_ProiectContext _context;

        public IndexModel(Andronic_Paul_Proiect.Data.Andronic_Paul_ProiectContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;
        public StudentData StudentData { get; set; }
        public int StudentID { get; set; }
        public int ExamID { get; set; }
        public async Task OnGetAsync(int? id, int? examID)
        {
            StudentData = new StudentData();

            StudentData.Students = await _context.Student
            .Include(b => b.Faculty)
            .Include(b => b.StudentExam)
            .ThenInclude(b => b.Exam)
            .AsNoTracking()
            .OrderBy(b => b.LastName)
            .ToListAsync();
            if (id != null)
            {
                StudentID = id.Value;
                Student student = StudentData.Students
                .Where(i => i.ID == id.Value).Single();
                StudentData.Exams = student.StudentExam.Select(s => s.Exam);
            }
        }

       
    }
}
