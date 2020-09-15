using CustomORM.Mapping;
using System;

namespace AccessToDb.Models
{
    /// <summary>
    /// Represents a Exam entity.
    /// </summary>
    [DbTable("Exams")]
    public class Exam
    {
        /// <summary>
        /// ExamID field.
        /// </summary>
        [DbColumn("ExamID", IsPrimaryKey = true)]
        public int ExamID { get; set; }

        /// <summary>
        /// SubjectID field.
        /// </summary>
        [DbColumn("SubjectID")]
        public int SubjectID { get; set; }

        /// <summary>
        /// Date field.
        /// </summary>
        [DbColumn("ExamDate")]
        public DateTime ExamDate { get; set; }

        /// <summary>
        /// StudentID field.
        /// </summary>
        [DbColumn("StudentID")]
        public int StudentID { get; set; }

        /// <summary>
        /// Mark field.
        /// </summary>
        [DbColumn("Mark")]
        public int Mark { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Exam exam &&
                   ExamID == exam.ExamID &&
                   SubjectID == exam.SubjectID &&
                   ExamDate == exam.ExamDate &&
                   StudentID == exam.StudentID &&
                   Mark == exam.Mark;
        }

        public override int GetHashCode()
        {
            int hashCode = 517185996;
            hashCode = hashCode * -1521134295 + ExamID.GetHashCode();
            hashCode = hashCode * -1521134295 + SubjectID.GetHashCode();
            hashCode = hashCode * -1521134295 + ExamDate.GetHashCode();
            hashCode = hashCode * -1521134295 + StudentID.GetHashCode();
            hashCode = hashCode * -1521134295 + Mark.GetHashCode();
            return hashCode;
        }
    }
}
