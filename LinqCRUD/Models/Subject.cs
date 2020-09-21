using System;
using System.Data.Linq.Mapping;

namespace LinqCRUD.Models
{
    [Table(Name = "Subject")]
    public class Subject
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(CanBeNull = false)]
        public string SubjectName { get; set; }
    }
}
