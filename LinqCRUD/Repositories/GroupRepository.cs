using LinqCRUD.Models;
using System.Linq;

namespace LinqCRUD.Repositories
{
    public class GroupRepository : Repository<Group>
    {
        public IQueryable<Group> GetGroups()
        {
            return GetAll();
        }
    }
}
