using System;
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
    }
}
