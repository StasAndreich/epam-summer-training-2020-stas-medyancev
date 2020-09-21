namespace BusinessLogicUsingLinq.DTOs
{
    /// <summary>
    /// Data transfer object for storing session statistics.
    /// </summary>
    public class SessionStatistics
    {
        public string GroupName { get; set; }
        public float MinMark { get; set; }
        public float AvgMark { get; set; }
        public float MaxMark { get; set; }
    }
}
