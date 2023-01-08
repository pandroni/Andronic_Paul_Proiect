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

namespace Andronic_Paul_Proiect.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly Andronic_Paul_Proiect.Data.Andronic_Paul_ProiectContext _context;

        public CreateModel(Andronic_Paul_Proiect.Data.Andronic_Paul_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Faculty>(), "ID","FacultyName");

            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Student.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
