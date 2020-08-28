using System;

namespace AccessToDb.Models
{
    public class Assessments
    {
        public int AssessmentID { get; set; }
        public int SubjectID { get; set; }
        public DateTime Date { get; set; }
        public int StudentID { get; set; }
        public string Result { get; set; }
    }
}
