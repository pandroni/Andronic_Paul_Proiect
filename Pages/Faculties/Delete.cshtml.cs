using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Andronic_Paul_Proiect.Data;
using Andronic_Paul_Proiect.Models;

namespace Andronic_Paul_Proiect.Pages.Faculties
{
    public class DeleteModel : PageModel
    {
        private readonly Andronic_Paul_Proiect.Data.Andronic_Paul_ProiectContext _context;

        public DeleteModel(Andronic_Paul_Proiect.Data.Andronic_Paul_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Faculty Faculty { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Faculty == null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculty.FirstOrDefaultAsync(m => m.ID == id);

            if (faculty == null)
            {
                return NotFound();
            }
            else 
            {
                Faculty = faculty;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Faculty == null)
            {
                return NotFound();
            }
            var faculty = await _context.Faculty.FindAsync(id);

            if (faculty != null)
            {
                Faculty = faculty;
                _context.Faculty.Remove(Faculty);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
