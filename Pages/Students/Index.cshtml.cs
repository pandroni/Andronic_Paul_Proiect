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

        public async Task OnGetAsync()
        {
            if (_context.Student != null)
            {
                Student = await _context.Student.Include(b => b.Faculty).ToListAsync();
            }
        }
    }
}
