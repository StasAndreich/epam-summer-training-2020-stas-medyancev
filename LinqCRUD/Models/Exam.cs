using System;
using System.Data.Linq.Mapping;

namespace LinqCRUD.Models
{
    [Table(Name = "Exam")]
    public class Exam
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public int SubjectId { get; set; }

        [Column]
        public DateTime ExamDate { get; set; }

        [Column]
        public int StudentId { get; set; }

        [Column]
        public int Mark { get; set; }

        [Column]
        public int ExaminerId { get; set; }
    }
}
