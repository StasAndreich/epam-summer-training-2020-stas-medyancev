namespace BusinessLogicUsingLinq.DTOs
{
    /// <summary>
    /// Data transfer object for storing session results.
    /// </summary>
    public class SessionResults
    {
        public string StudentFirstName { get; set; }
        public string StudentLastname { get; set; }
        public string StudentPatronymic { get; set; }
        public string GroupName { get; set; }
        public string SubjectName { get; set; }
        public string Result { get; set; }
    }
}
