namespace AccessToDb.Contracts
{
    public interface IDaoFactory
    {
        ISubjectDao GetSubjectDao();
        IStudentDao GetStudentDao();
        IGroupDao GetGroupDao();
        IExamDao GetExamDao();
        IAssessmentDao GetAssessmentDao();
    }
}
