using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidzy_DIY
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a VidzyDbContext instance
            VidzyDbContext dbContext = new VidzyDbContext();
            
            //// Delete all videos in the database
            //dbContext.DeleteAllVideos();

            //// Insert some videos to the database
            //CreateVideos(dbContext);

            // Print out all videos in the database
            DisplayVideos(dbContext);
        }

        private static void DisplayVideos(VidzyDbContext dbContext)
        {
            var videos = dbContext.GetVideos();
            foreach (var item in videos)
            {
                Console.WriteLine(
                    $"ID: {item.Id}, " +
                    $"Name: {item.Name}, " +
                    $"Release Date: {item.RealeaseDate.ToShortDateString()}," +
                    $" Genre: {item.Genre}");
            }
            Console.WriteLine();
        }

        private static void CreateVideos(VidzyDbContext dbContext)
        {
            int count = 0;

            string[] videoNames =
            {
                "A romance lover",
                "A happy family",
                "A thriller film",
                "A horrible night",
                "A action movie",
                "A comedy couple"
            };

            DateTime[] releaseDates =
            {
                DateTime.Parse("11-05-1984"),
                DateTime.Parse("12-31-1985"),
                DateTime.Parse("03-14-1994"),
                DateTime.Now,
                DateTime.Parse("05-28-1985"),
                DateTime.Parse("01-23-2016"),
            };

            string[] genres =
            {
                "romance",
                "family",
                "thriller",
                "horror",
                "action",
                "comedy"
            };

            for (int i = 0; i < 6; i++)
            {
                dbContext.AddVideo(videoNames[i], releaseDates[i], genres[i]);
                count++;
            }
            Console.WriteLine($" {count} video(s) is added");
        }
    }
}
