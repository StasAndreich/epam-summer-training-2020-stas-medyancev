using AccessToDb.Contexts;
using AccessToDb.Contracts;

namespace AccessToDb.DAOs
{
    /// <summary>
    /// Provides access to all DAO's.
    /// </summary>
    public class DaoFactory : IDaoFactory
    {
        /// <summary>
        /// Creates an AssessmentDAO.
        /// </summary>
        /// <returns></returns>
        public IAssessmentDao GetAssessmentDao()
        {
            return new AssessmentDAO();
        }

        /// <summary>
        /// Creates an ExamDAO.
        /// </summary>
        /// <returns></returns>
        public IExamDao GetExamDao()
        {
            return new ExamDAO();
        }

        /// <summary>
        /// Creates a GroupDAO.
        /// </summary>
        /// <returns></returns>
        public IGroupDao GetGroupDao()
        {
            return new GroupDAO();
        }

        /// <summary>
        /// Creates a StudentDAO.
        /// </summary>
        /// <returns></returns>
        public IStudentDao GetStudentDao()
        {
            return new StudentDAO();
        }

        /// <summary>
        /// Creates a SubjectDAO.
        /// </summary>
        /// <returns></returns>
        public ISubjectDao GetSubjectDao()
        {
            return new SubjectDAO();
        }
    }
}
