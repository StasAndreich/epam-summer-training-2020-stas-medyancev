using AccessToDb.Contexts;
using AccessToDb.Contracts;

namespace AccessToDb.DAOs
{
    /// <summary>
    /// Provides access to all DAO's.
    /// </summary>
    public class DaoFactory : IDaoFactory
    {
        public IAssessmentDao GetAssessmentDao()
        {
            return new 
        }

        public IExamDao GetExamDao()
        {
            throw new System.NotImplementedException();
        }

        public IGroupDao GetGroupDao()
        {
            return new GroupDAO();
        }

        public IStudentDao GetStudentDao()
        {
            throw new System.NotImplementedException();
        }

        public ISubjectDao GetSubjectDao()
        {
            throw new System.NotImplementedException();
        }
    }
}
