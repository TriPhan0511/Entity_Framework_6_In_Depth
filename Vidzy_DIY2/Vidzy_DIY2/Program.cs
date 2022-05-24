using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidzy_DIY2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a VidzyDbContext instance
            var dbContext = new VidzyDbContext();

            //// There are two ways to add a new video into the database
            //// Add a new video without calling a stored procedure
            //var video = new Video();
            //video.Name = "Testing FILM";
            //video.RealeaseDate = DateTime.Now;
            //video.GenreId = 1;
            //video.Classification = Classification.Gold;
            //dbContext.Videos.Add(video);
            //dbContext.SaveChanges();

            // Add a new video via calling a stored procedure
            dbContext.AddVideo("Testing FILM 2", DateTime.Parse("11-05-1984"), "action", Classification.Platinum);

            // Print out the records in the "Videos" table
            DisplayVideos(dbContext);
        }

        private static void DisplayVideos(VidzyDbContext dbContext)
        {
            foreach (var v in dbContext.Videos)
            {
                Console.WriteLine(
                    $"Video Id: {v.Id}, " +
                    $"Title: {v.Name}, " +
                    $"Release Date: {v.RealeaseDate.ToShortDateString()}, " +
                    $"Genre Id: {v.GenreId}, " +
                    $"Genre: {v.Genre.Name}, " +
                    $"Genre: {v.Classification}");
            }
            Console.WriteLine();
        }

        ////--------------------------------------------------------------------------------------------------
        //static void Main(string[] args)
        //{

        //    // Create a VidzyDbContext instance
        //    var dbContext = new VidzyDbContext();

        //    //// 1st Iteration
        //    //// Insert some videos to the database
        //    //CreateVideos(dbContext);

        //    //// Print out the records in the "Videos" table
        //    //foreach (var v in dbContext.Videos)
        //    //{
        //    //    Console.WriteLine(
        //    //        $"Video Id: {v.Id}, " +
        //    //        $"Title: {v.Name}, " +
        //    //        $"Release Date: {v.RealeaseDate.ToShortDateString()}, " +
        //    //        $"Genre Id: {v.GenreId}, " +
        //    //        $"Genre: {v.Genre.Name}");
        //    //}
        //    //Console.WriteLine();

        //    ////---------------------------------------------------------------
        //    //// 2nd Iteration

        //    //// Print out the records in the "Videos" table
        //    //foreach (var v in dbContext.Videos)
        //    //{
        //    //    Console.WriteLine(
        //    //        $"Video Id: {v.Id}, " +
        //    //        $"Title: {v.Name}, " +
        //    //        $"Release Date: {v.RealeaseDate.ToShortDateString()}, " +
        //    //        $"Genre Id: {v.GenreId}, " +
        //    //        $"Genre: {v.Genre.Name}");
        //    //}
        //    //Console.WriteLine();

        //    //// Add a new video
        //    //string title = "A horrible coffee cup";
        //    //DateTime now = DateTime.Now;
        //    //string genre = "horror";
        //    //dbContext.AddVideo(title, now, genre);

        //    //// Print out the records in the "Videos" table
        //    //foreach (var v in dbContext.Videos)
        //    //{
        //    //    Console.WriteLine(
        //    //        $"Video Id: {v.Id}, " +
        //    //        $"Title: {v.Name}, " +
        //    //        $"Release Date: {v.RealeaseDate.ToShortDateString()}, " +
        //    //        $"Genre Id: {v.GenreId}, " +
        //    //        $"Genre: {v.Genre.Name}");
        //    //}
        //    //Console.WriteLine();

        //    ////---------------------------------------------------------------
        //    // 3rd Iteration

        //    //// Add some videos to the database (use the new edition of CreateVideos() method)
        //    //CreateVideos_2(dbContext);

        //    // Print out the records in the "Videos" table
        //    foreach (var v in dbContext.Videos)
        //    {
        //        Console.WriteLine(
        //            $"Video Id: {v.Id}, " +
        //            $"Title: {v.Name}, " +
        //            $"Release Date: {v.RealeaseDate.ToShortDateString()}, " +
        //            $"Genre Id: {v.GenreId}, " +
        //            $"Genre: {v.Genre.Name}, " +
        //            $"Genre: {v.Classification}");
        //    }
        //    Console.WriteLine();
        //}

        // Helper method
        private static void CreateVideos_2(VidzyDbContext dbContext)
        {
            string[] titles =
            {
                "A COMEDY Film",
                "A ACTION Film",
                "A HORROR Film",
                "A THRILLER Film",
                "A FAMILY Film",
                "A ROMANCE Film",
            };

            DateTime[] releaseDates =
            {
                DateTime.Parse("11-05-1984"),
                DateTime.Parse("05-28-1985"),
                DateTime.Parse("01-23-2016"),
                DateTime.Parse("03-14-1994"),
                DateTime.Parse("05-23-2022"),
                DateTime.Now
            };

            string[] genres =
            {
                "comedy",
                "action",
                "horror",
                "thriller",
                "family",
                "romance"
            };

            Classification[] classifications =
            {
                Classification.Silver,
                Classification.Gold,
                Classification.Platinum,
                Classification.Silver,
                Classification.Gold,
                Classification.Platinum,
            };

            int count = 0;
            for (int i = 0; i < 6; i++)
            {
                dbContext.AddVideo(titles[i], releaseDates[i], genres[i], classifications[i]);
                count++;
            }
            Console.WriteLine($"{count} videos was added");
        }

        //private static void CreateVideos(VidzyDbContext dbContext)
        //{
        //    string[] titles =
        //    {
        //        "A COMEDY Film",
        //        "A ACTION Film",
        //        "A HORROR Film",
        //        "A THRILLER Film",
        //        "A FAMILY Film",
        //        "A ROMANCE Film",
        //    };

        //    DateTime[] releaseDates =
        //    {
        //        DateTime.Parse("11-05-1984"),
        //        DateTime.Parse("05-28-1985"),
        //        DateTime.Parse("01-23-2016"),
        //        DateTime.Parse("03-14-1994"),
        //        DateTime.Parse("05-23-2022"),
        //        DateTime.Now
        //    };

        //    string[] genres =
        //    {
        //        "comedy",
        //        "action",
        //        "horror",
        //        "thriller",
        //        "family",
        //        "romance"
        //    };

        //    int count = 0;
        //    for (int i = 0; i < 6; i++)
        //    {
        //        dbContext.AddVideo(titles[i], releaseDates[i], genres[i]);
        //        count++;
        //    }
        //    Console.WriteLine($"{count} videos was added");
        //}
    }
}
