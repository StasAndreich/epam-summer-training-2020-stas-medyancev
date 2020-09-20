using LinqCRUD.Models;
using System.Linq;

namespace LinqCRUD.Contracts
{
    /// <summary>
    /// Repository for Examiner model.
    /// </summary>
    public interface IExaminerRepository : IRepository<Examiner>
    {
        /// <summary>
        /// Returns entity table.
        /// </summary>
        /// <returns></returns>
        IQueryable<Examiner> GetExaminers();
    }
}
