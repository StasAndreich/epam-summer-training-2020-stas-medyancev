using AccessToDb.Contracts;
using AccessToDb.Models;
using CustomORM.DataAccess;
using System;
using System.Collections.Generic;

namespace AccessToDb.DAOs
{
    /// <summary>
    /// Describes a Subject DAO.
    /// </summary>
    public class SubjectDAO : SqlDao<Subject>, ISubjectDao
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Subject IEnumerable.</returns>
        public IEnumerable<Subject> GetSubjects()
        {
            throw new NotImplementedException();
        }
    }
}
