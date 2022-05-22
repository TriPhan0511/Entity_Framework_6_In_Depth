using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new DatabaseFirstDemoEntities();
            //var post = new Post
            var post = new Post()
            {
                PostID = 1,
                DatePublished = DateTime.Now,
                Title = "Titke",
                Body = "Body"
            };
            context.Posts.Add(post);
            int affectedRecords = context.SaveChanges();
            if (affectedRecords != 0)
            {
                Console.WriteLine("A record was added.");
            }
        }
    }
}
