using System;
using System.Collections.Generic;
using AccessToDb.Contracts;
using AccessToDb.Models;
using CustomORM.DataAccess;

namespace AccessToDb.Contexts
{
    public class GroupDAO : SqlDao<Group>, IGroupDao
    {
        public IEnumerable<Group> GetGroups()
        {
            throw new NotImplementedException();
        }
    }
}
