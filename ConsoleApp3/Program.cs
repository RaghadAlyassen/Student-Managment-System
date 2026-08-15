
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;


namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()

               .UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=MyNewSchoolDB;Trusted_Connection=True;TrustServerCertificate=True;")
               .Options;
    
            //EX invalid Age
            using var db = new ApplicationDbContext(options);

            var student = new Student

            {
                Id = 11,

                FullName = "Test Student",

                Email = "test@gmail.com",

                Age = 15,

                percentage = 80

            };

            db.Students.Add(student);

            db.SaveChanges();
            // EXinvalid Email
            var students = new Student
            {
                Id = 12,
                FullName = "Test Student",
                Email = "invalidemail",
                Age = 20,
                percentage = 80
            };

            db.Students.Add(student);
            db.SaveChanges();


            //Ex invalid Description
            var course = new Course
            {
                Id = 6,
                Name = "Test Course",
                Description = new string('A', 151),
                DurationinHours = 20
            };

            db.Courses.Add(course);
            db.SaveChanges();






        }
    }

    
}
