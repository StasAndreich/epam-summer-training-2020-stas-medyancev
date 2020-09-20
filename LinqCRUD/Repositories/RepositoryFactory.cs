using LinqCRUD.Contracts;
using System;

namespace LinqCRUD.Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IAssessmentRepository GetAssessmentRepository()
        {
            return new AssessmentRepository();
        }

        public IExaminerRepository GetExaminerRepository()
        {
            return new ExaminerRepository();
        }

        public IExamRepository GetExamRepository()
        {
            return new ExamRepository();
        }

        public IGroupRepository GetGroupRepository()
        {
            return new GroupRepository();
        }

        public ISpecialtyRepository GetSpecialtyRepository()
        {
            return new SpecialtyRepository();
        }

        public IStudentRepository GetStudentRepository()
        {
            return new StudentRepository();
        }

        public ISubjectRepository GetSubjectRepository()
        {
            return new SubjectRepository();
        }
    }
}
