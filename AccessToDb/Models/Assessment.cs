using CustomORM.Mapping;
using System;
using System.Collections.Generic;

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
        [DbColumn("AssessmentDate")]
        public DateTime AssessmentDate { get; set; }

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

        public override bool Equals(object obj)
        {
            return obj is Assessment assessment &&
                   AssessmentID == assessment.AssessmentID &&
                   SubjectID == assessment.SubjectID &&
                   AssessmentDate == assessment.AssessmentDate &&
                   StudentID == assessment.StudentID &&
                   Result == assessment.Result;
        }

        public override int GetHashCode()
        {
            int hashCode = -1612082888;
            hashCode = hashCode * -1521134295 + AssessmentID.GetHashCode();
            hashCode = hashCode * -1521134295 + SubjectID.GetHashCode();
            hashCode = hashCode * -1521134295 + AssessmentDate.GetHashCode();
            hashCode = hashCode * -1521134295 + StudentID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Result);
            return hashCode;
        }
    }
}
