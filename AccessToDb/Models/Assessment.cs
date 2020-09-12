using CustomORM.Mapping;
using System;

namespace AccessToDb.Models
{
    /// <summary>
    /// Represents a Assessment entity.
    /// </summary>
    [DbTable("Assessments")]
    public class Assessment
    {
        /// <summary>
        /// AssessmentID field.
        /// </summary>
        [DbColumn("AssessmentID", IsPrimaryKey = true)]
        public int AssessmentID { get; set; }

        /// <summary>
        /// SubjectID field.
        /// </summary>
        [DbColumn("SubjectID")]
        public int SubjectID { get; set; }

        /// <summary>
        /// Date field.
        /// </summary>
        [DbColumn("Date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// StudentID field.
        /// </summary>
        [DbColumn("StudentID")]
        public int StudentID { get; set; }

        /// <summary>
        /// Mark field.
        /// </summary>
        [DbColumn("Result")]
        public string Result { get; set; }
    }
}
