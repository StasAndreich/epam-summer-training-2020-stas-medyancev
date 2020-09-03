namespace AccessToDb.Contracts
{
    /// <summary>
    /// Defines all DAO layers for models.
    /// </summary>
    public interface IDaoFactory
    {
        /// <summary>
        /// Creates Subject DAO.
        /// </summary>
        /// <returns></returns>
        ISubjectDao GetSubjectDao();
        /// <summary>
        /// Creates Student DAO.
        /// </summary>
        /// <returns></returns>
        IStudentDao GetStudentDao();
        /// <summary>
        /// Creates Group DAO.
        /// </summary>
        /// <returns></returns>
        IGroupDao GetGroupDao();
        /// <summary>
        /// Creates Exam DAO.
        /// </summary>
        /// <returns></returns>
        IExamDao GetExamDao();
        /// <summary>
        /// Creates Assessment DAO.
        /// </summary>
        /// <returns></returns>
        IAssessmentDao GetAssessmentDao();
    }
}
