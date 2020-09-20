using System;
using System.Data.Linq.Mapping;

namespace LinqCRUD.Models
{
    [Table(Name = "Student")]
    public class Student
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(CanBeNull = false)]
        public string Name { get; set; }

        [Column(CanBeNull = false)]
        public string Surname { get; set; }

        [Column(CanBeNull = false)]
        public string Patronym { get; set; }

        [Column(CanBeNull = false)]
        public string Sex { get; set; }

        [Column(CanBeNull = false)]
        public DateTime BirthDate { get; set; }
        
        [Column]
        public int GroupId { get; set; }
    }
}
