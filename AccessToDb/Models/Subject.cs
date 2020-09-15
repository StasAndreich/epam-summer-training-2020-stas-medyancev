using CustomORM.Mapping;
using System.Collections.Generic;

namespace AccessToDb.Models
{
    /// <summary>
    /// Represents a Subject entity.
    /// </summary>
    [DbTable("Subjects")]
    public class Subject
    {
        /// <summary>
        /// SubjectID field.
        /// </summary>
        [DbColumn("SubjectID", IsPrimaryKey = true)]
        public int SubjectID { get; set; }

        /// <summary>
        /// SubjectName field.
        /// </summary>
        [DbColumn("SubjectName", CanBeNull = false)]
        public string SubjectName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Subject subject &&
                   SubjectID == subject.SubjectID &&
                   SubjectName == subject.SubjectName;
        }

        public override int GetHashCode()
        {
            int hashCode = 64492478;
            hashCode = hashCode * -1521134295 + SubjectID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SubjectName);
            return hashCode;
        }
    }
}
