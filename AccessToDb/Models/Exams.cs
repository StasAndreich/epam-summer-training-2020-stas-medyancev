using System;

namespace AccessToDb.Models
{
    public class Exams
    {
        public int ExamID { get; set; }
        public int SubjectID { get; set; }
        public DateTime Date { get; set; }
        public int StudentID { get; set; }
        public int Mark { get; set; }
    }
}
