using System;
using System.Data.Linq.Mapping;

namespace LinqCRUD.Models
{
    [Table(Name = "Student")]
    public class Student
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public string Surname { get; set; }

        [Column]
        public string Patronym { get; set; }

        [Column]
        public string Sex { get; set; }
        
        [Column]
        public DateTime BirthDate { get; set; }
        
        [Column]
        public int GroupId { get; set; }
    }
}
