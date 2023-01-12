using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Andronic_Paul_Proiect.Data;
using Andronic_Paul_Proiect.Models;
using System.Security.Policy;
using Andronic_Paul_Proiect.Models;
using System.Drawing.Printing;

namespace Andronic_Paul_Proiect.Pages.Students
{
    public class CreateModel : StudentExamPageModel
    {
        private readonly Andronic_Paul_Proiect.Data.Andronic_Paul_ProiectContext _context;

        public CreateModel(Andronic_Paul_Proiect.Data.Andronic_Paul_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["FacultyID"] = new SelectList(_context.Set<Faculty>(), "ID","FacultyName");
            var student = new Student();
            student.StudentExam = new List<StudentExam>();
            PopulateAssignedExamData(_context, student);

            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedExams)
        {
            var newStudent = new Student();
            if (selectedExams != null)
            {
                newStudent.StudentExam = new List<StudentExam>();
                foreach (var exam in selectedExams)
                {
                    var examToAdd = new StudentExam
                    {
                        ExamID = int.Parse(exam)
                    };

                    newStudent.StudentExam.Add(examToAdd);
                }
            }
            if (selectedExams == null)
            {
                var examToAdd = new StudentExam();
                newStudent.StudentExam.Add(examToAdd);
            }


            if (await TryUpdateModelAsync<Student>(
            newStudent,
            "Student",
          i => i.FirstName, i => i.LastName, i => i.Email, i => i.PhoneNumber, i => i.CreatedDate, i => i.FacultyID))
              
            {
                _context.Student.Add(newStudent);
                await _context.SaveChangesAsync();
               
                return RedirectToPage("./Index");
            }
            PopulateAssignedExamData(_context, newStudent);
            return Page();
        }
    }
}
