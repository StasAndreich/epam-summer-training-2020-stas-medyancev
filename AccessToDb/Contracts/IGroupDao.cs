using System.Collections.Generic;
using CustomORM.DataAccess;
using AccessToDb.Models;

namespace AccessToDb.Contracts
{
    public interface IGroupDao : IDao<Group>
    {
        IEnumerable<Group> GetGroups();
    }
}