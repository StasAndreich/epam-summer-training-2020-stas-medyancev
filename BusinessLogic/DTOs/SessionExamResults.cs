namespace BusinessLogic
{
    /// <summary>
    /// Data transfer object for storing session results.
    /// </summary>
    public class SessionResults
    {
        public readonly string studentFirstName;
        public readonly string studentLastname;
        public readonly string studentPatronymic;
        public readonly string groupName;
        public readonly string subjectName;
        public readonly string result;

        /// <summary>
        /// Default ctor.
        /// </summary>
        /// <param name="stFirstName"></param>
        /// <param name="stLastname"></param>
        /// <param name="stPat"></param>
        /// <param name="grName"></param>
        /// <param name="subjName"></param>
        /// <param name="result"></param>
        public SessionResults(string stFirstName,
                                   string stLastname,
                                   string stPat,
                                   string grName,
                                   string subjName,
                                   string result)
        {
            this.studentFirstName = stFirstName;
            this.studentLastname = stLastname;
            this.studentPatronymic = stPat;
            this.groupName = grName;
            this.subjectName = subjName;
            this.result = result;
        }
    }
}
