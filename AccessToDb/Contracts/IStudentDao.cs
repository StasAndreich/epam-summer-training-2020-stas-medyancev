using System.Collections.Generic;
using CustomORM.DataAccess;
using AccessToDb.Models;

namespace AccessToDb.Contracts
{
    /// <summary>
    /// DAO for Student model.
    /// </summary>
    public interface IStudentDao : IDao<Student>
    {
        /// <summary>
        /// Contains entity table.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Student> GetStudents();
    }
}