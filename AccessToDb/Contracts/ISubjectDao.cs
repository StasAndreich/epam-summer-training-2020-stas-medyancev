using System.Collections.Generic;
using CustomORM.DataAccess;
using AccessToDb.Models;

namespace AccessToDb.Contracts
{
    /// <summary>
    /// DAO for Subject model.
    /// </summary>
    public interface ISubjectDao : IDao<Subject>
    {
        /// <summary>
        /// Contains entity table.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Subject> GetSubjects();
    }
}