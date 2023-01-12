using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Andronic_Paul_Proiect.Data;
using Andronic_Paul_Proiect.Models;

namespace Andronic_Paul_Proiect.Pages.StudentExams
{
    public class DeleteModel : PageModel
    {
        private readonly Andronic_Paul_Proiect.Data.Andronic_Paul_ProiectContext _context;

        public DeleteModel(Andronic_Paul_Proiect.Data.Andronic_Paul_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public StudentExam StudentExam { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StudentExam == null)
            {
                return NotFound();
            }

            var studentexam = await _context.StudentExam.FirstOrDefaultAsync(m => m.ID == id);

            if (studentexam == null)
            {
                return NotFound();
            }
            else 
            {
                StudentExam = studentexam;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.StudentExam == null)
            {
                return NotFound();
            }
            var studentexam = await _context.StudentExam.FindAsync(id);

            if (studentexam != null)
            {
                StudentExam = studentexam;
                _context.StudentExam.Remove(StudentExam);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
