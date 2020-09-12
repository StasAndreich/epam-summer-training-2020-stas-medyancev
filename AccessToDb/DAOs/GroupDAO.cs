using System;
using System.Collections.Generic;
using AccessToDb.Contracts;
using AccessToDb.Models;
using CustomORM.DataAccess;

namespace AccessToDb.Contexts
{
    /// <summary>
    /// Describes a Group DAO.
    /// </summary>
    public class GroupDAO : SqlDao<Group>, IGroupDao
    {
        /// <summary>
        /// </summary>
        /// <returns>Groups IEnumerable.</returns>
        public IEnumerable<Group> GetGroups()
        {
            return GetAll();
        }
    }
}
