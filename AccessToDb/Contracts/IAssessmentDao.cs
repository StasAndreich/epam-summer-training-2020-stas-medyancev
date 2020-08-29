using System.Collections.Generic;
using CustomORM.DataAccess;
using AccessToDb.Models;

namespace AccessToDb.Contracts
{
    public interface IAssessmentDao : IDao<Assessment>
    {
        IEnumerable<Assessment> GetAssessments();
    }
}