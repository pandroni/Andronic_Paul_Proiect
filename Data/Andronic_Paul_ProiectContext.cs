using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Andronic_Paul_Proiect.Models;

namespace Andronic_Paul_Proiect.Data
{
    public class Andronic_Paul_ProiectContext : DbContext
    {
        public Andronic_Paul_ProiectContext (DbContextOptions<Andronic_Paul_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Andronic_Paul_Proiect.Models.Student> Student { get; set; } = default!;

        public DbSet<Andronic_Paul_Proiect.Models.Faculty> Faculty { get; set; }

        public DbSet<Andronic_Paul_Proiect.Models.Exam> Exam { get; set; }

        public DbSet<Andronic_Paul_Proiect.Models.StudentExam> StudentExam { get; set; }


        public DbSet<Andronic_Paul_Proiect.Models.Admin> Admin { get; set; }

    }
}
