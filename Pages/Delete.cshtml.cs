using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Andronic_Paul_Proiect.Data;
using Andronic_Paul_Proiect.Models;

namespace Andronic_Paul_Proiect.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Andronic_Paul_Proiect.Data.Andronic_Paul_ProiectContext _context;

        public DeleteModel(Andronic_Paul_Proiect.Data.Andronic_Paul_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Admin Admin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Admin == null)
            {
                return NotFound();
            }

            var admin = await _context.Admin.FirstOrDefaultAsync(m => m.ID == id);

            if (admin == null)
            {
                return NotFound();
            }
            else 
            {
                Admin = admin;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Admin == null)
            {
                return NotFound();
            }
            var admin = await _context.Admin.FindAsync(id);

            if (admin != null)
            {
                Admin = admin;
                _context.Admin.Remove(Admin);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
