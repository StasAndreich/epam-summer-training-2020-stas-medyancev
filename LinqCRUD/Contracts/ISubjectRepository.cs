using LinqCRUD.Models;
using System.Linq;

namespace LinqCRUD.Contracts
{
    /// <summary>
    /// Repository for Subject model.
    /// </summary>
    public interface ISubjectRepository : IRepository<Subject>
    {
        /// <summary>
        /// Returns entity table.
        /// </summary>
        /// <returns></returns>
        IQueryable<Subject> GetSubjects();
    }
}
