using CustomORM.Mapping;
using System;

namespace AccessToDb.Models
{
    /// <summary>
    /// Represents a Exam entity.
    /// </summary>
    [DbTable(Name = "Exams")]
    public class Exam
    {
        /// <summary>
        /// ExamID field.
        /// </summary>
        [DbColumn(IsPrimaryKey = true)]
        public int ExamID { get; set; }

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
        public int Mark { get; set; }
    }
}
