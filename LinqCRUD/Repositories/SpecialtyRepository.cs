using LinqCRUD.Models;
using System.Data.Linq;

namespace LinqCRUD.Repositories
{
    public class SpecialtyRepository : Repository<Specialty>
    {
        protected override Table<Specialty> GetTable()
        {
            return context.GetTable<Specialty>();
        }
    }
}
