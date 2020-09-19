using System;
using System.Data.Linq.Mapping;

namespace LinqCRUD.Models
{
    [Table(Name = "Assessment")]
    public class Assessment
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public int SubjectId { get; set; }

        [Column]
        public DateTime AssessmentDate { get; set; }

        [Column]
        public int StudentId { get; set; }

        [Column]
        public string Result { get; set; }

        [Column]
        public int ExaminerId { get; set; }
    }
}
