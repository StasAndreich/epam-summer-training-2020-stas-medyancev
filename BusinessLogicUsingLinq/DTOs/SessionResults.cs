namespace BusinessLogicUsingLinq.DTOs
{
    /// <summary>
    /// Data transfer object for storing session results.
    /// </summary>
    public class SessionResults
    {
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentPatronym { get; set; }
        public string GroupName { get; set; }
        public string SubjectName { get; set; }
        public string Result { get; set; }
    }
}
