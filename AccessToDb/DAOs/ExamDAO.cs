using AccessToDb.Contracts;
using AccessToDb.Models;
using CustomORM.DataAccess;
using System.Collections.Generic;

namespace AccessToDb.DAOs
{
    /// <summary>
    /// Describes an Exam DAO.
    /// </summary>
    public class ExamDAO : SqlDao<Exam>, IExamDao
    {
        /// <summary>
        /// </summary>
        /// <returns>Exams IEnumerable.</returns>
        public IEnumerable<Exam> GetExams()
        {
            throw new System.NotImplementedException();
        }
    }
}
