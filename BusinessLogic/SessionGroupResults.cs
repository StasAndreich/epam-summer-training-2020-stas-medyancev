namespace BusinessLogic
{
    internal class SessionGroupResults
    {
        private string studentName;
        private string studentSurname;
        private string studentPatronymic;
        private string groupName;
        private string subjectName;
        private int result;

        public SessionGroupResults(string stName,
                                   string stSurname,
                                   string stPat,
                                   string grName,
                                   string subjName,
                                   int result)
        {
            this.studentName = stName;
            this.studentSurname = stSurname;
            this.studentPatronymic = stPat;
            this.groupName = grName;
            this.subjectName = subjName;
            this.result = result;
        }
    }
}
