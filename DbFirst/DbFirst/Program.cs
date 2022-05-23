using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var course = new Course();
            //course.Level = CourseLevel.Beginner; // 1
            course.Level = Level.Beginner;
        }

        //static void Main(string[] args)
        //{
        //    /*
        //        Call a procedure
        //     */

        //    // Create a PlutoDbContext instance
        //    PlutoDbContext dbContext = new PlutoDbContext();

        //    // Get all of courses (call a stored procedure)
        //    var courses = dbContext.GetCourses();
        //    foreach (var item in courses)
        //    {
        //        Console.WriteLine($"CourseID: {item.CourseID}, AuthorIDl: {item.AuthorID}," +
        //            $" Title: {item.Title}, Description: {item.Description}," +
        //            $" Price: {item.FullPrice:C2}, Level: {item.Level}");
        //    }
        //    //// Output:
        //    ////CourseID: 1, AuthorIDl: 1, Title: C# Advanced, Description: C# Advanced Description, Price: $69.00, Level: 3
        //    ////CourseID: 2, AuthorIDl: 1, Title: C# Intermediate, Description: C# Intermediate Description, Price: $49.00, Level: 2
        //    ////CourseID: 3, AuthorIDl: 1, Title: Clean Code, Description: Clean Code Description, Price: $99.00, Level: 2

        //    ////Insert a new course: ERROR
        //    //int authorID = 2;
        //    //string title = "Entity Framework 6 in Depth";
        //    //string description = "This course from codewithmosh.com";
        //    ////short price = Convert.ToInt16(15);
        //    //short price = (short)15;
        //    //string levelString = "Intermetidate";
        //    //byte level = 3;
        //    //int affectedRows = dbContext.InsertCourse(authorID, title, description, price, levelString, level);
        //    //dbContext.SaveChanges();
        //    //if (affectedRows != 0)
        //    //{
        //    //    Console.WriteLine($"{affectedRows} record(s) added.");
        //    //}
        //}
    }
}
