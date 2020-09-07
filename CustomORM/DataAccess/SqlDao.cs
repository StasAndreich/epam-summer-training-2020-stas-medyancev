using CustomORM.Mapping;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace CustomORM.DataAccess
{
    /// <summary>
    /// Provides an access to a database table.
    /// </summary>
    public abstract class SqlDao<TModel> : IDao<TModel>
        where TModel : class, new()
    {
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
                        // temp!
                        // replace with name from attrib (use reflection to
                        // init the name)
                        idFieldName = member.Name;
                        break;
                    }
                }

                // temp!
                SqlDbContext.ConnectionString = @"Data Source=DESKTOP-PF22DB1\SQLEXPRESS;Initial Catalog=UniversityDB;Integrated Security=True";
                // Open connection.
                SqlDbContext.Connection.Open();

                var command = SqlDbContext.Connection.CreateCommand();
                command.CommandText = $"SELECT * FROM {tableName} WHERE {idFieldName}=@id;";
                command.CommandType = System.Data.CommandType.Text;

                command.Parameters.Add(new SqlParameter("@id", id));
                var reader = (SqlDataReader) command.ExecuteReader();
                object[] objects = new object[2];// temp

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        reader.GetValues(objects);
                    }
                }
                else
                    throw new ApplicationException("There is nothing to get by this ID.");

                reader.Close();

                // Close connection.
                SqlDbContext.Connection.Close();
                return (TModel) Activator.CreateInstance(type, objects);
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

        public IEnumerable<TModel> GetAll()
        {

        }
    }
}
