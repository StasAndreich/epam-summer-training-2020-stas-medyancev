using AccessToDb.Contracts;
using AccessToDb.Models;
using CustomORM.DataAccess;
using System;
using System.Collections.Generic;

namespace AccessToDb.DAOs
{
    /// <summary>
    /// Describes a Student DAO.
    /// </summary>
    public class StudentDAO : SqlDao<Student>, IStudentDao
    {
        /// <summary>
        /// </summary>
        /// <returns>Students IEnumerable.</returns>
        public IEnumerable<Student> GetStudents()
        {
            return GetAll();
        }
    }
}
