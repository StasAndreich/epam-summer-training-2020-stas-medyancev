using System;
using System.Data.Linq.Mapping;

namespace LinqCRUD.Models
{
    [Table(Name = "Specialty")]
    public class Specialty
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        
        [Column]
        public string SpecialtyName { get; set; }
    }
}
