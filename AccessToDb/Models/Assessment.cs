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
        [DbColumn(IsPrimaryKey = true)]
        public int AssessmentID { get; set; }

        /// <summary>
        /// SubjectID field.
        /// </summary>
        [DbColumn]
        public int SubjectID { get; set; }

        /// <summary>
        /// Date field.
        /// </summary>
        [DbColumn]
        public DateTime Date { get; set; }

        /// <summary>
        /// StudentID field.
        /// </summary>
        [DbColumn]
        public int StudentID { get; set; }

        /// <summary>
        /// Mark field.
        /// </summary>
        [DbColumn]
        public string Result { get; set; }
    }
}
