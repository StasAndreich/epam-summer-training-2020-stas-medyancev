using System.Collections.Generic;
using CustomORM.DataAccess;
using AccessToDb.Models;

namespace AccessToDb.Contracts
{
    /// <summary>
    /// DAO for Assessment model.
    /// </summary>
    public interface IAssessmentDao : IDao<Assessment>
    {
        /// <summary>
        /// Contains entity table.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Assessment> GetAssessments();
    }
}