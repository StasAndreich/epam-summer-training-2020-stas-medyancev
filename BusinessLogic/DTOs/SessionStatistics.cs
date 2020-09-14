namespace BusinessLogic.DTOs
{
    /// <summary>
    /// Data transfer object for storing session statistics.
    /// </summary>
    public class SessionStatistics
    {
        public string groupName;
        public float minMark;
        public float avgMark;
        public float maxMark;

        /// <summary>
        /// Default ctor.
        /// </summary>
        /// <param name="grName"></param>
        /// <param name="minMark"></param>
        /// <param name="avgMark"></param>
        /// <param name="maxMark"></param>
        public SessionStatistics(string grName,
                                 float minMark,
                                 float avgMark,
                                 float maxMark)
        {
            this.groupName = grName;
            this.minMark = minMark;
            this.avgMark = avgMark;
            this.maxMark = maxMark;
        }
    }
}
