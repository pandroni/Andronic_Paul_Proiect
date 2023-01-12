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
    public class IndexModel : PageModel
    {
        private readonly Andronic_Paul_Proiect.Data.Andronic_Paul_ProiectContext _context;

        public IndexModel(Andronic_Paul_Proiect.Data.Andronic_Paul_ProiectContext context)
        {
            _context = context;
        }

        public IList<StudentExam> StudentExam { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.StudentExam != null)
            {
                StudentExam = await _context.StudentExam
                .Include(s => s.Exam)
                .Include(s => s.Student).ToListAsync();
            }
        }
    }
}
