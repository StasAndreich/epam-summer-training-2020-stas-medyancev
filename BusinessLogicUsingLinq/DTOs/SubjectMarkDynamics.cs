using System.Collections.Generic;

namespace BusinessLogicUsingLinq.DTOs
{
    public class SubjectMarkDynamics
    {
        public string SubjectName { get; set; }
        public Dictionary<int, float> AvgMarksByYears { get; set; }
    }
}
