using System;
using System.Collections.Generic;
using CustomORM.Mapping;

namespace AccessToDb.Models
{
    /// <summary>
    /// Represents a Student entity.
    /// </summary>
    [DbTable("Students")]
    public class Student
    {
        /// <summary>
        /// StudentId field.
        /// </summary>
        [DbColumn("StudentID", IsPrimaryKey = true)]
        public int StudentID { get; set; }

        /// <summary>
        /// FirstName field.
        /// </summary>
        [DbColumn("FirstName", CanBeNull = false)]
        public string FirstName { get; set; }

        /// <summary>
        /// LastName field.
        /// </summary>
        [DbColumn("LastName", CanBeNull = false)]
        public string LastName { get; set; }

        /// <summary>
        /// PatronymicName field.
        /// </summary>
        [DbColumn("PatronymicName", CanBeNull = false)]
        public string PatronymicName { get; set; }

        /// <summary>
        /// Sex field.
        /// </summary>
        [DbColumn("Sex", CanBeNull = false)]
        public string Sex { get; set; }

        /// <summary>
        /// BirthDate field.
        /// </summary>
        [DbColumn("BirthDate", CanBeNull = false)]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// GroupID field.
        /// </summary>
        [DbColumn("GroupID")]
        public int GroupID { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   StudentID == student.StudentID &&
                   FirstName == student.FirstName &&
                   LastName == student.LastName &&
                   PatronymicName == student.PatronymicName &&
                   Sex == student.Sex &&
                   BirthDate == student.BirthDate &&
                   GroupID == student.GroupID;
        }

        public override int GetHashCode()
        {
            int hashCode = -896933197;
            hashCode = hashCode * -1521134295 + StudentID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PatronymicName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Sex);
            hashCode = hashCode * -1521134295 + BirthDate.GetHashCode();
            hashCode = hashCode * -1521134295 + GroupID.GetHashCode();
            return hashCode;
        }
    }
}
