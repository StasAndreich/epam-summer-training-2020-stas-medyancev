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
            throw new System.NotImplementedException();
        }

        public IExamDao GetExamDao()
        {
            throw new System.NotImplementedException();
        }

        public IGroupDao GetGroupDao()
        {
            throw new System.NotImplementedException();
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
