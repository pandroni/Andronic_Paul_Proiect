using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Andronic_Paul_Proiect.Data;
using Andronic_Paul_Proiect.Models;
using System.Security.Policy;
using Andronic_Paul_Proiect.Migrations;
using Faculty = Andronic_Paul_Proiect.Models.Faculty;

namespace Andronic_Paul_Proiect.Pages.Students
{
    public class EditModel : StudentExamPageModel
    {
        private readonly Andronic_Paul_Proiect.Data.Andronic_Paul_ProiectContext _context;

        public EditModel(Andronic_Paul_Proiect.Data.Andronic_Paul_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student = await _context.Student
            .Include(b => b.Faculty)
            .Include(b => b.StudentExam).ThenInclude(b => b.Exam)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);
            if (Student == null)
            {
                return NotFound();
            }
      
            PopulateAssignedExamData(_context, Student);
       
            ViewData["FacultyID"] = new SelectList(_context.Set<Faculty>(), "ID", "FacultyName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedExams)
        {
            if (id == null)
            {
                return NotFound();
            }
            var studentToUpdate = await _context.Student
            .Include(i => i.Faculty)
            .Include(i => i.StudentExam)
            .ThenInclude(i => i.Exam)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (studentToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Student>(
            studentToUpdate,
            "Student",
            i => i.FirstName, i => i.LastName,
            i => i.Email, i => i.PhoneNumber, i => i.CreatedDate, i => i.FacultyID))
            {
                UpdateStudentExams(_context, selectedExams, studentToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateStudentExams(_context, selectedExams, studentToUpdate);
            PopulateAssignedExamData(_context, studentToUpdate);
            return Page();
        }
        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.ID == id);
        }
    }
   
}





