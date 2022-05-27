namespace CodeFirstTesting3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Courses")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        // Change Title property to Name property
        //public string Title { get; set; }
        public string Name { get; set; }

        public int Level { get; set; }

        //// Add a new property named DatePublished
        //// (it's a nullabel column in the database, so we use DateTime?)
        //public DateTime? DatePublished { get; set; }

        public decimal Price { get; set; }

        public int? Author_Id { get; set; }

        public virtual Author Author { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
