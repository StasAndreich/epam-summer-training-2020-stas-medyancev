using LinqCRUD.Models;
using System.Linq;

namespace LinqCRUD.Contracts
{
    /// <summary>
    /// Repository for Assessment model.
    /// </summary>
    public interface IAssessmentRepository : IRepository<Assessment>
    {
        /// <summary>
        /// Returns entity table.
        /// </summary>
        /// <returns></returns>
        IQueryable<Assessment> GetAssessments();
    }
}
