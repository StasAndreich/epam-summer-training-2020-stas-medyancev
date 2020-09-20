using LinqCRUD.Models;
using System.Linq;

namespace LinqCRUD.Contracts
{
    /// <summary>
    /// Repository for Specialty model.
    /// </summary>
    public interface ISpecialtyRepository : IRepository<Specialty>
    {
        /// <summary>
        /// Returns entity table.
        /// </summary>
        /// <returns></returns>
        IQueryable<Specialty> GetSpecialties();
    }
}
