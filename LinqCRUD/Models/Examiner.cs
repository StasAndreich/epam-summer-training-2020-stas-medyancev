using System;
using System.Data.Linq.Mapping;

namespace LinqCRUD.Models
{
    [Table(Name = "Examiner")]
    public class Examiner
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(CanBeNull = false)]
        public string Name { get; set; }

        [Column(CanBeNull = false)]
        public string Surname { get; set; }

        [Column(CanBeNull = false)]
        public string Patronym { get; set; }
    }
}
