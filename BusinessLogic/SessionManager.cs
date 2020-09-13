using AccessToDb.Contracts;
using AccessToDb.Models;
using BusinessLogic;
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
        /// Gets session results IEnumerable.
        /// </summary>
        internal IEnumerable<SessionGroupResults> GetSessionResults()
        {
            // Join tables.
            var results = from student in GetStudents()
                          join gr in GetGroups()
                            on student.GroupID equals gr.GroupID
                          join exam in GetExams()
                            on student.StudentID equals exam.StudentID
                          join subject in GetSubjects()
                            on exam.SubjectID equals subject.SubjectID
                          select new SessionGroupResults(student.FirstName,
                                                         student.LastName,
                                                         student.PatronymicName,
                                                         gr.GroupName,
                                                         subject.SubjectName,
                                                         exam.Mark);
            //var t = 5;
            return results;
        }
    }
}
