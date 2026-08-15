using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace ConsoleApp3
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext ()
        {

        }
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
        
            : base(options)

        { 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

       

                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=MyNewSchoolDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }



        public DbSet<Student> Students { get; set; }
        public DbSet<Course>  Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configration Student

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>()
                .HasKey(S => S.Id);


            modelBuilder.Entity<Student>()
                .Property(S => S.FullName)
                .HasColumnName( "Name");


            modelBuilder.Entity<Student>()
                  .Property(S => S.percentage)
                  .HasPrecision(4,2);



            modelBuilder.Entity<Student>()
            .HasCheckConstraint("CK_Email", "Email LIKE '%@%'" );


           
            
           Console.WriteLine("===========================================================================");

            //Configration Course

            modelBuilder.Entity<Student>()
                 .HasCheckConstraint("CK_Age", "Age=> 16");

            modelBuilder.Entity<Course>()
                .HasKey(C => C.Id);



            modelBuilder.Entity<Course>()
                .Property(C => C.Description)
                .HasColumnType("VARCHAR")
                .HasMaxLength(150);

            //Student Seeding

            modelBuilder.Entity<Student>().HasData(
            new Student
            {
                Id = 1,
                FullName = "Shahed",
                Email = "shahed@gmail.com",
                Age = 25,
                percentage = 95
            },





               new Student
               {
                   Id = 2,
                   FullName = "Mohamed",
                   Email = "mohamed@gmial.com",
                   Age = 20,
                   percentage = 85

               },




               new Student
               {
                   Id = 3,
                   FullName = "Ahmed",
                   Email = "ahmed@gmial.com",
                   Age = 29,
                   percentage = 80

               },





               new Student
               {
                   Id = 4,
                   FullName = "Marwa",
                   Email = "marwa@gmial.com",
                   Age = 21,
                   percentage = 90

               },





              new Student
              {
                  Id = 5,
                  FullName = "Renad",
                  Email = "renad@gmial.com",
                  Age = 23,
                  percentage = 86

              },





             new Student
             {
                 Id = 6,
                 FullName = "Ali",
                 Email = "ali@gmial.com",
                 Age = 28,
                 percentage = 89

             },




             new Student
             {
                 Id = 7,
                 FullName = "Omar",
                 Email = "omar@gmial.com",
                 Age = 18,
                 percentage = 70

             },






             new Student
             {
                 Id = 8,
                 FullName = "Mona",
                 Email = "mona@gmial.com",
                 Age = 24,
                 percentage = 91

             },




             new Student
             {
                 Id = 9,
                 FullName = "Mazen",
                 Email = "mazen@gmial.com",
                 Age = 19,
                 percentage = 83

             },







             new Student
             {
                 Id = 10,
                 FullName = "Yara",
                 Email = "yara@gmial.com",
                 Age = 22,
                 percentage = 75

             }

             );


            //Seeding Courses

            modelBuilder.Entity<Course>().HasData(
             new Course
             {
              Id= 1,
              Name="OOP",
              Description="Object oriented programming",
              DurationinHours=20,

             },

             new Course
             {
                 Id = 2,
                 Name = "C#",
                 Description = "C# programming",
                 DurationinHours = 25,

             },


             new Course
             {
                 Id = 3,
                 Name = "SQL",
                 Description = "Learn SQl Queries",
                 DurationinHours = 30,

             },

             new Course
             {
                 Id = 4,
                 Name="DB",
                 Description = "Learn Data base",
                 DurationinHours = 15,

             },


             new Course
             {
                 Id = 5,
                 Name = "Entity FrameWork",
                 Description = "Learn EF core",
                 DurationinHours = 10,

             }


















          );
        }

    }


    
    }
