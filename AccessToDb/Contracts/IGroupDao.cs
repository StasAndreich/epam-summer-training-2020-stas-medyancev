using System.Collections.Generic;
using CustomORM.DataAccess;
using AccessToDb.Models;

namespace AccessToDb.Contracts
{
    /// <summary>
    /// DAO for Group model.
    /// </summary>
    public interface IGroupDao : IDao<Group>
    {
        /// <summary>
        /// Contains entity table.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Group> GetGroups();
    }
}