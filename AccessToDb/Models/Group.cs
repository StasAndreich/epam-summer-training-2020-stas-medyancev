using CustomORM.Mapping;
using System.Collections.Generic;

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

        public override bool Equals(object obj)
        {
            return obj is Group group &&
                   GroupID == group.GroupID &&
                   GroupName == group.GroupName;
        }

        public override int GetHashCode()
        {
            int hashCode = -149169712;
            hashCode = hashCode * -1521134295 + GroupID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GroupName);
            return hashCode;
        }
    }
}
