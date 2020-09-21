using BusinessLogicUsingLinq.DTOs;
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
        /// Get average mark by every specialty.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public IQueryable<SpecialtyStatistics> GetSpecialtyStatistics (DateTime startDate,
                                                             DateTime endDate,
                                                             Func<IQueryable<SpecialtyStatistics>,
                                                                IQueryable<SpecialtyStatistics>> sort)
        {
            var specialtiesStats = from exam in GetExams()
                                   join student in GetStudents()
                                      on exam.StudentId equals student.Id
                                   join gr in GetGroups()
                                      on student.GroupId equals gr.Id
                                   join specialty in GetSpecialties()
                                      on gr.SpecialtyId equals specialty.Id
                                   where exam.ExamDate >= startDate &&
                                        exam.ExamDate <= endDate
                                   group exam by specialty.SpecialtyName into specResults
                                   select new SpecialtyStatistics()
                                   {
                                       SpecialtyName = specResults.Key,
                                       AvgMark = (float)specResults.Average(s => s.Mark)
                                   };

            return sort(specialtiesStats);
        }

        /// <summary>
        /// Get average mark by every examiner.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public IQueryable<ExaminerStatistics> GetExaminerStatistics(DateTime startDate,
                                                             DateTime endDate,
                                                             Func<IQueryable<ExaminerStatistics>,
                                                                IQueryable<ExaminerStatistics>> sort)
        {
            var specialtiesStats = from exam in GetExams()
                                   join examiner in GetExaminers()
                                       on exam.ExaminerId equals examiner.Id
                                   where exam.ExamDate >= startDate &&
                                       exam.ExamDate <= endDate
                                   group exam by examiner.Surname into examinerResults
                                   select new ExaminerStatistics()
                                   {
                                       ExaminerName = examinerResults.Key,
                                       AvgMark = (float)examinerResults.Average(s => s.Mark)
                                   };

            return sort(specialtiesStats);
        }

        /// <summary>
        /// Gets session results IEnumerable by date interval.
        /// </summary>
        public IQueryable<SessionResults> GetSessionResults(DateTime startDate,
                                                             DateTime endDate,
                                                             Func<IQueryable<SessionResults>,
                                                                IQueryable<SessionResults>> sort)
        {
            // Join tables on exams.
            var examResults = from student in GetStudents()
                              join gr in GetGroups()
                                on student.GroupId equals gr.Id
                              join exam in GetExams()
                                on student.Id equals exam.Id
                              join subject in GetSubjects()
                                on exam.SubjectId equals subject.Id
                              where exam.ExamDate >= startDate && exam.ExamDate <= endDate
                              select new SessionResults()
                              {
                                  StudentName = student.Name,
                                  StudentSurname = student.Surname,
                                  StudentPatronym = student.Patronym,
                                  GroupName = gr.GroupName,
                                  SubjectName = subject.SubjectName,
                                  Result = exam.Mark.ToString()
                              };

            // Join tables on assessments.
            var assessmentResults = from student in GetStudents()
                                    join gr in GetGroups()
                                      on student.GroupId equals gr.Id
                                    join assessment in GetAssessments()
                                      on student.Id equals assessment.Id
                                    join subject in GetSubjects()
                                      on assessment.SubjectId equals subject.Id
                                    where assessment.AssessmentDate >= startDate &&
                                          assessment.AssessmentDate <= endDate
                                    select new SessionResults()
                                    {
                                        StudentName = student.Name,
                                        StudentSurname = student.Surname,
                                        StudentPatronym = student.Patronym,
                                        GroupName = gr.GroupName,
                                        SubjectName = subject.SubjectName,
                                        Result = assessment.Result
                                    };

            var result = examResults.Concat(assessmentResults);

            return sort(result);
        }

        /// <summary>
        /// Returns a min-avg-max session statictics by groups.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public IQueryable<SessionStatistics> GetSessionStatistics(DateTime startDate,
                                                                   DateTime endDate,
                                                                   Func<IQueryable<SessionStatistics>,
                                                                       IQueryable<SessionStatistics>> sort)
        {
            var statistics = from student in GetStudents()
                             join gr in GetGroups()
                               on student.GroupId equals gr.Id
                             join exam in GetExams()
                               on student.Id equals exam.StudentId
                             where exam.ExamDate >= startDate &&
                                exam.ExamDate <= endDate
                             group exam by gr.GroupName into marks
                             select new SessionStatistics()
                             {
                                 GroupName = marks.Key,
                                 MinMark = marks.Min(e => e.Mark),
                                 AvgMark = (float)marks.Average(e => e.Mark),
                                 MaxMark = marks.Max(e => e.Mark)
                             };

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
                               on student.GroupId equals gr.Id
                           join exam in GetExams()
                               on student.Id equals exam.StudentId
                           where exam.ExamDate >= startDate &&
                                exam.ExamDate <= endDate &&
                                exam.Mark < 4 && exam.Mark >= 1
                           select new ContributableStudents()
                           {
                               GroupName = gr.GroupName,
                               Name = student.Name,
                               Surname = student.Surname,
                               Patronym = student.Patronym,
                               Mark = exam.Mark
                           };

            return sort(students);
        }
    }
}
