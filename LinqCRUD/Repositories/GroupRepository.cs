using LinqCRUD.Contracts;
using LinqCRUD.Models;
using System.Linq;

namespace LinqCRUD.Repositories
{
    public class GroupRepository : Repository<Group>,
        IGroupRepository
    {
        public IQueryable<Group> GetGroups()
        {
            return GetAll();
        }
    }
}
