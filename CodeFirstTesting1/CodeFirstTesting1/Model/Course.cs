using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTesting1
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CourseLevel Level { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Author Author { get; set; }
        public Category Categories { get; set; }
        public IList<Tag> Tags { get; set; }
    }
}
