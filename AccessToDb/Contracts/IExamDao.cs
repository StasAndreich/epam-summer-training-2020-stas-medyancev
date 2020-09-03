using System.Collections.Generic;
using CustomORM.DataAccess;
using AccessToDb.Models;

namespace AccessToDb.Contracts
{
    /// <summary>
    /// DAO for Exam model.
    /// </summary>
    public interface IExamDao : IDao<Exam>
    {
        /// <summary>
        /// Contains entity table.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Exam> GetExams();
    }
}