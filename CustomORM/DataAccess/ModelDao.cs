using System;
using System.Data.SqlClient;

namespace CustomORM.DataAccess
{
    /// <summary>
    /// Provides an access to a database table.
    /// </summary>
    public abstract class ModelDao<TModel> : IDao<TModel>
        where TModel : class, new()
    {
        protected SqlConnection Context
        {
            get => DbContextManager.Context;
        }

        public void Insert(TModel entity)
        {
            var conn = Context;
            conn.Open();



            var parameter = new SqlParameter("@name", );
            // get table names from reflection.
            var sqlExp = "INSERT INTO ";
            var commnand = new SqlCommand("d", conn);

            conn.Close();
        }

        public void Delete(TModel entity)
        {
            throw new NotImplementedException();
        }        

        public void SubmitChanges()
        {
            throw new NotImplementedException();
        }
    }
}
