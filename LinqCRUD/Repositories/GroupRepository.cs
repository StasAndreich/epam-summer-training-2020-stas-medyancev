using LinqCRUD.Models;
using System;
using System.Data.Linq;

namespace LinqCRUD.Repositories
{
    public class GroupRepository : Repository<Group>
    {
        protected override Table<Group> GetTable()
        {
            return context.GetTable<Group>();
        }
    }
}
