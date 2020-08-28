using System;
using CustomORM.Mapping;

namespace AccessToDb.Models
{
    /// <summary>
    /// Represents a Student entity.
    /// </summary>
    [DbTable(Name = "Students")]
    public class Student
    {
        /// <summary>
        /// StudentId field.
        /// </summary>
        [DbColumn(IsPrimaryKey = true)]
        public int StudentId { get; set; }

        /// <summary>
        /// FirstName field.
        /// </summary>
        [DbColumn]
        public string FirstName { get; set; }

        /// <summary>
        /// LastName field.
        /// </summary>
        [DbColumn]
        public string LastName { get; set; }

        /// <summary>
        /// PatronymicName field.
        /// </summary>
        [DbColumn]
        public string PatronymicName { get; set; }

        /// <summary>
        /// Sex field.
        /// </summary>
        [DbColumn]
        public string Sex { get; set; }

        /// <summary>
        /// BirthDate field.
        /// </summary>
        [DbColumn]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// GroupID field.
        /// </summary>
        [DbColumn]
        public int GroupID { get; set; }
    }
}
