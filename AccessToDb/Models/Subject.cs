using CustomORM.Mapping;

namespace AccessToDb.Models
{
    /// <summary>
    /// Represents a Subject entity.
    /// </summary>
    [DbTable(Name = "Subjects")]
    public class Subject
    {
        /// <summary>
        /// SubjectID field.
        /// </summary>
        [DbColumn(IsPrimaryKey = true)]
        public int SubjectID { get; set; }

        /// <summary>
        /// SubjectName field.
        /// </summary>
        [DbColumn(CanBeNull = false)]
        public string SubjectName { get; set; }
    }
}
