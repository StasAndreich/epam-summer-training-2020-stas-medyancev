using CustomORM.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CustomORM.DataAccess
{
    /// <summary>
    /// Provides an access to a database table.
    /// </summary>
    public abstract class SqlDao<TModel> : IDao<TModel>
        where TModel : class, new()
    {
        #region Additional props

        /// <summary>
        /// Gets a database context.
        /// </summary>
        protected SqlDbContext Context
        {
            get => SqlDbContext.Context;
        }

        /// <summary>
        /// Gets a database connection.
        /// </summary>
        protected SqlConnection Connection
        {
            get => (SqlConnection)SqlDbContext.Context.Connection;
        }

        #endregion

        /// <summary>
        /// Creates a new entity in its table.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TModel entity)
        {
            
        }

        /// <summary>
        /// Selects an entity from database by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TModel Get(int id)
        {
            var type = typeof(TModel);

            // Check table attrib.
            var tableAttrib = (DbTableAttribute) DbModelMappingCheker
                .CheckDbTableAttrib(type);

            if (tableAttrib != null)
            {
                // Get a table name.
                var tableName = tableAttrib.Name;
                var idFieldName = "";

                // Find primary key member.
                var members = type.GetMembers();
                foreach (var member in members)
                {
                    var colAttrib = (DbColumnAttribute) DbModelMappingCheker
                        .CheckDbColumnAttrib(member);

                    if (colAttrib == null) continue;
                    if (colAttrib.IsPrimaryKey == true)
                    {
                        idFieldName = colAttrib.Name;
                        break;
                    }
                }

                // Open connection.
                Connection.Open();

                var command = Connection.CreateCommand();
                command.CommandText = $"SELECT * FROM {tableName} " +
                    $"WHERE {idFieldName}=@id;";
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.Add(new SqlParameter("@id", id));

                var reader = (SqlDataReader) command.ExecuteReader();

                //var values = new List<object>();
                // Create list, not array.
                //
                // ???

                // sqladapter -> datarow.itemarray

                //var adapter = new SqlDataAdapter(command);
                //var ds = new DataSet();

                //adapter.Fill(ds);
                var values = new object[reader.FieldCount];

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                    }
                }
                else
                    throw new ApplicationException("There is nothing to get by this ID.");

                reader.Close();

                //var dataTable = ds.Tables[0];
                //object[] obj = null;
                //foreach (DataRow row in dataTable.Rows)
                //{
                //    obj = row.ItemArray;
                //}

                // Close connection.
                Connection.Close();

                var model = (TModel)Activator.CreateInstance(type, values);
                var props = model.GetType().GetProperties();
                
                return 
            }
            else
                throw new ApplicationException("Current TModel is not a DB table.");
        }

        public void Remove(TModel entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TModel entity)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<TModel> GetAll()
        //{

        //}
    }
}
