using System;
using System.Data.Linq.Mapping;

namespace LinqCRUD.Models
{
    [Table(Name = "Group")]
    public class Group
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(CanBeNull = false)]
        public string GroupName { get; set; }
        
        [Column()]
        public int SpecialtyId { get; set; }
    }
}
