using AccessToDb.Contracts;
using AccessToDb.Models;
using CustomORM.DataAccess;
using System.Collections.Generic;

namespace AccessToDb.DAOs
{
    /// <summary>
    /// Describes a Assessment DAO.
    /// </summary>
    public class AssessmentDAO : SqlDao<Assessment>, IAssessmentDao
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Assessment IEnumerable.</returns>
        public IEnumerable<Assessment> GetAssessments()
        {
            return GetAll();
        }
    }
}
