using LinqCRUD.Contracts;
using LinqCRUD.Models;
using System.Linq;

namespace BusinessLogicUsingLinq
{
    /// <summary>
    /// Business logic of a session.
    /// </summary>
    public class SessionManager
    {
        private readonly IRepositoryFactory repositoryFactory;

        public SessionManager(IRepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }

        public IQueryable<Assessment> GetAssessments()
        {
            var repos = repositoryFactory.GetAssessmentRepository();
            return repos.GetAssessments();
        }

        public IQueryable<Exam> GetExams()
        {
            var repos = repositoryFactory.GetExamRepository();
            return repos.GetExams();
        }

        public IQueryable<Student> GetStudents()
        {
            var repos = repositoryFactory.GetStudentRepository();
            return repos.GetStudents();
        }

        public IQueryable<Subject> GetSubjects()
        {
            var repos = repositoryFactory.GetSubjectRepository();
            return repos.GetSubjects();
        }

        public IQueryable<Examiner> GetExaminers()
        {
            var repos = repositoryFactory.GetExaminerRepository();
            return repos.GetExaminers();
        }

        public IQueryable<Specialty> GetSpecialties()
        {
            var repos = repositoryFactory.GetSpecialtyRepository();
            return repos.GetSpecialties();
        }

        public IQueryable<Group> GetGroups()
        {
            var repos = repositoryFactory.GetGroupRepository();
            return repos.GetGroups();
        }
    }
}
