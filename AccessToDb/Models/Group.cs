using CustomORM.Mapping;

namespace AccessToDb.Models
{
    /// <summary>
    /// Represents a Group entity.
    /// </summary>
    [DbTable("Groups")]
    public class Group
    {
        /// <summary>
        /// GroupID field.
        /// </summary>
        [DbColumn("GroupID", IsPrimaryKey = true)]
        public int GroupID { get; set; }

        /// <summary>
        /// GroupName field.
        /// </summary>
        [DbColumn("GroupName", CanBeNull = false)]
        public string GroupName { get; set; }
    }
}
