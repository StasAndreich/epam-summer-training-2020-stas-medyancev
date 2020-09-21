using LinqCRUD.Contracts;
using LinqCRUD.Models;
using System;
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

        /// <summary>
        /// Gets session results IEnumerable by date interval.
        /// </summary>
        public IEnumerable<SessionResults> GetSessionResults(DateTime startDate,
                                                             DateTime endDate,
                                                             Func<IEnumerable<SessionResults>,
                                                                    IEnumerable<SessionResults>> sort)
        {
            // Join tables on exams.
            var examResults = from student in GetStudents()
                              join gr in GetGroups()
                                on student.GroupID equals gr.GroupID
                              join exam in GetExams()
                                on student.StudentID equals exam.StudentID
                              join subject in GetSubjects()
                                on exam.SubjectID equals subject.SubjectID
                              where exam.ExamDate >= startDate && exam.ExamDate <= endDate
                              select new SessionResults(student.FirstName,
                                                             student.LastName,
                                                             student.PatronymicName,
                                                             gr.GroupName,
                                                             subject.SubjectName,
                                                             exam.Mark.ToString());

            // Join tables on assessments.
            var assessmentResults = from student in GetStudents()
                                    join gr in GetGroups()
                                      on student.GroupID equals gr.GroupID
                                    join assessment in GetAssessments()
                                      on student.StudentID equals assessment.StudentID
                                    join subject in GetSubjects()
                                      on assessment.SubjectID equals subject.SubjectID
                                    where assessment.AssessmentDate >= startDate &&
                                          assessment.AssessmentDate <= endDate
                                    select new SessionResults(student.FirstName,
                                                                   student.LastName,
                                                                   student.PatronymicName,
                                                                   gr.GroupName,
                                                                   subject.SubjectName,
                                                                   assessment.Result);

            var result = new List<SessionResults>(examResults.Count() +
                                                         assessmentResults.Count());
            result.AddRange(examResults);
            result.AddRange(assessmentResults);

            return sort(result);
        }

        /// <summary>
        /// Returns a min-avg-max session statictics by groups.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public IEnumerable<SessionStatistics> GetSessionStatistics(DateTime startDate,
                                                                   DateTime endDate,
                                                                   Func<IEnumerable<SessionStatistics>,
                                                                       IEnumerable<SessionStatistics>> sort)
        {
            var statistics = from student in GetStudents()
                             join gr in GetGroups()
                               on student.GroupID equals gr.GroupID
                             join exam in GetExams()
                               on student.StudentID equals exam.StudentID
                             where exam.ExamDate >= startDate &&
                                exam.ExamDate <= endDate
                             group exam by gr.GroupName into marks
                             select new SessionStatistics(marks.Key,
                                                          marks.Min(e => e.Mark),
                                                          (float)marks.Average(e => e.Mark),
                                                          marks.Max(e => e.Mark));

            return sort(statistics);
        }

        /// <summary>
        /// Returns a contributable students IEnumerable.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public IQueryable<ContributableStudents> GetContributableStudents(DateTime startDate,
                                                                    DateTime endDate,
                                                                    Func<IQueryable<ContributableStudents>,
                                                                    IQueryable<ContributableStudents>> sort)
        {
            var students = from student in GetStudents()
                           join gr in GetGroups()
                               on student.Id equals gr.Id
                           join exam in GetExams()
                               on student.Id equals exam.Id
                           where exam.ExamDate >= startDate &&
                                exam.ExamDate <= endDate &&
                                exam.Mark < 4 && exam.Mark >= 1
                           select new ContributableStudents()
                           {
                               groupName = gr.GroupName,
                               name = student.FirstName,
                               lastName = student.LastName,
                               patronym = student.PatronymicName,
                               mark = exam.Mark
                           };

            return sort(students);
        }
    }
}
