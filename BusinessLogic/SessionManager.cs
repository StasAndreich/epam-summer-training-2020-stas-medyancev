using AccessToDb.Contracts;
using AccessToDb.Models;
using BusinessLogic;
using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccessToDb
{
    /// <summary>
    /// Business logic of a session.
    /// </summary>
    public class SessionManager
    {
        private readonly IDaoFactory daoFactory;

        /// <summary>
        /// Default ctor.
        /// </summary>
        /// <param name="factory"></param>
        public SessionManager(IDaoFactory factory)
        {
            this.daoFactory = factory;
        }

        /// <summary>
        /// Gets Exams.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Exam> GetExams()
        {
            var dao = daoFactory.GetExamDao();
            return dao.GetExams();
        }

        /// <summary>
        /// Gets Assessments.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Assessment> GetAssessments()
        {
            var dao = daoFactory.GetAssessmentDao();
            return dao.GetAssessments();
        }

        /// <summary>
        /// Gets Students.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Student> GetStudents()
        {
            var dao = daoFactory.GetStudentDao();
            return dao.GetStudents();
        }

        /// <summary>
        /// Gets Subjects.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Subject> GetSubjects()
        {
            var dao = daoFactory.GetSubjectDao();
            return dao.GetSubjects();
        }

        /// <summary>
        /// Gets Groups.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Group> GetGroups()
        {
            var dao = daoFactory.GetGroupDao();
            return dao.GetGroups();
        }

        /// <summary>
        /// Gets session results IEnumerable by date interval.
        /// </summary>
        public IEnumerable<SessionResults> GetSessionResults(DateTime startDate,
                                                                    DateTime endDate)
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

            result.OrderBy(r => r.studentLastname);

            return result;
        }

        /// <summary>
        /// Returns a min-avg-max session statictics by groups.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public IEnumerable<SessionStatistics> GetSessionStatistics(DateTime startDate,
                                                                    DateTime endDate)
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
            // Apply sorting.
            statistics.OrderBy(stat => stat.groupName);

            return statistics;
        }

        /// <summary>
        /// Returns a contributable students IEnumerable.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public IEnumerable<ContributableStudents> GetContributableStudents(DateTime startDate,
                                                                    DateTime endDate)
        {
            var students = from student in GetStudents()
                           join gr in GetGroups()
                               on student.GroupID equals gr.GroupID
                           join exam in GetExams()
                               on student.StudentID equals exam.StudentID
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
            students.OrderBy(st => st.lastName);

            return students;
        }
    }
}
