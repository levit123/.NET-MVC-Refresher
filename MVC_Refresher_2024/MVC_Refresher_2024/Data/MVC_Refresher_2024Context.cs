using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_Refresher_2024.Models;

namespace MVC_Refresher_2024.Data
{
    public class MVC_Refresher_2024Context : DbContext
    {
        public MVC_Refresher_2024Context (DbContextOptions<MVC_Refresher_2024Context> options)
            : base(options)
        {
        }

        public DbSet<MVC_Refresher_2024.Models.Teacher> Teacher { get; set; } = default!;
        public DbSet<MVC_Refresher_2024.Models.CollegeClass> CollegeClass { get; set; } = default!;
        public DbSet<MVC_Refresher_2024.Models.Student> Student { get; set; } = default!;
    }
}
