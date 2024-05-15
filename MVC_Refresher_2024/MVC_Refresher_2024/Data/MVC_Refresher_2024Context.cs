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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //setting the primary key for the Teacher entity in the SQL database
            modelBuilder.Entity<Teacher>().HasKey(x => x.TeacherID);

            //populates the Teacher table with entries
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { TeacherID = 1, TeacherName = "Smith" },
                new Teacher { TeacherID = 2, TeacherName = "Johnson" },
                new Teacher { TeacherID = 3, TeacherName = "Allison" }
               );

            modelBuilder.Entity<CollegeClass>().HasKey(x => x.CollegeClassID);

            modelBuilder.Entity<CollegeClass>().HasData(
                new CollegeClass { CollegeClassID = 1, CollegeClassName = "History 101", CollegeClassTeacher = (Teacher)Teacher.Where(x => x.TeacherID == 1) },
                new CollegeClass { CollegeClassID = 2, CollegeClassName = "Math 101", CollegeClassTeacher = (Teacher)Teacher.Where(x => x.TeacherID == 2) },
                new CollegeClass { CollegeClassID = 3, CollegeClassName = "Science 101", CollegeClassTeacher = (Teacher)Teacher.Where(x => x.TeacherID == 3) },
                new CollegeClass { CollegeClassID = 4, CollegeClassName = "History 202", CollegeClassTeacher = (Teacher)Teacher.Where(x => x.TeacherID == 1) },
                new CollegeClass { CollegeClassID = 5, CollegeClassName = "Math 202", CollegeClassTeacher = (Teacher)Teacher.Where(x => x.TeacherID == 2) },
                new CollegeClass { CollegeClassID = 6, CollegeClassName = "Science 202", CollegeClassTeacher = (Teacher)Teacher.Where(x => x.TeacherID == 3) }
                );

            modelBuilder.Entity<Student>().HasKey(x => x.StudentID );

            modelBuilder.Entity<Student>().HasData(
                new Student {
                    StudentID = 1,
                    StudentFName = "Bob",
                    StudentLName = "Jones",
                    collegeClasses = [ (CollegeClass)CollegeClass.Where(x => x.CollegeClassID == 1 && x.CollegeClassID == 2 && x.CollegeClassID == 3) ]
                },
                new Student
                {
                    StudentID = 2,
                    StudentFName = "Albert",
                    StudentLName = "Goldstein",
                    collegeClasses = [(CollegeClass)CollegeClass.Where(x => x.CollegeClassID == 4 && x.CollegeClassID == 5 && x.CollegeClassID == 3)]
                },
                new Student
                {
                    StudentID = 3,
                    StudentFName = "Sarah",
                    StudentLName = "Silverman",
                    collegeClasses = [(CollegeClass)CollegeClass.Where(x => x.CollegeClassID == 1 && x.CollegeClassID == 2 && x.CollegeClassID == 6)]
                },
                new Student
                {
                    StudentID = 4,
                    StudentFName = "Johnny",
                    StudentLName = "Bravo",
                    collegeClasses = [(CollegeClass)CollegeClass.Where(x => x.CollegeClassID == 4 && x.CollegeClassID == 2 && x.CollegeClassID == 6)]
                },
                new Student
                {
                    StudentID = 5,
                    StudentFName = "Melvin",
                    StudentLName = "Ohulahan",
                    collegeClasses = [(CollegeClass)CollegeClass.Where(x => x.CollegeClassID == 4 && x.CollegeClassID == 5 && x.CollegeClassID == 6)]
                },
                new Student
                {
                    StudentID = 6,
                    StudentFName = "Jimmy",
                    StudentLName = "Jameson",
                    collegeClasses = [(CollegeClass)CollegeClass.Where(x => x.CollegeClassID == 4 && x.CollegeClassID == 1 && x.CollegeClassID == 2)]
                },
                new Student
                {
                    StudentID = 7,
                    StudentFName = "Nelly",
                    StudentLName = "Wilkerson",
                    collegeClasses = [(CollegeClass)CollegeClass.Where(x => x.CollegeClassID == 4 && x.CollegeClassID == 5 && x.CollegeClassID == 6)]
                },
                new Student
                {
                    StudentID = 8,
                    StudentFName = "Joey",
                    StudentLName = "LooseLips",
                    collegeClasses = [(CollegeClass)CollegeClass.Where(x => x.CollegeClassID == 1 && x.CollegeClassID == 2 && x.CollegeClassID == 3)]
                }
                );
        }
    }
}
