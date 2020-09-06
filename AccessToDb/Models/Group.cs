using CustomORM.Mapping;

namespace AccessToDb.Models
{
    /// <summary>
    /// Represents a Group entity.
    /// </summary>
    [DbTable(Name = "Groups")]
    public class Group
    {
        /// <summary>
        /// GroupID field.
        /// </summary>
        [DbColumn(IsPrimaryKey = true)]
        public int GroupID { get; set; }

        /// <summary>
        /// GroupName field.
        /// </summary>
        [DbColumn(CanBeNull = false)]
        public string GroupName { get; set; }

        public Group()
        {

        }

        public Group(int id, string name)
        {
            GroupID = id;
            GroupName = name;
        }
    }
}
