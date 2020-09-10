using CustomORM.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter("@id", id));

                // Execute reader.
                var reader = (SqlDataReader) command.ExecuteReader();
                var namedValues = GetNamedValuesPairs(reader);
                reader.Close();

                // Get models.
                var models = InstantiateModelsFromNamedValues(namedValues);

                // Close connection.
                Connection.Close();

                return models.FirstOrDefault();
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

        /// <summary>
        /// Reads data from a database as named values pairs belonging to a table.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"/>
        internal IEnumerable<IDictionary<string, object>> GetNamedValuesPairs(SqlDataReader reader)
        {
            var namedValuesDictionariesList = new List<Dictionary<string, object>>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var nameValueDictionary = new Dictionary<string, object>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var name = reader.GetName(i);
                        var value = reader.GetValue(i);
                        nameValueDictionary.Add(name, value);
                    }

                    namedValuesDictionariesList.Add(nameValueDictionary);
                }
            }
            else
                throw new ApplicationException("There is nothing to get by this ID.");

            return namedValuesDictionariesList;
        }

        /// <summary>
        /// Instantiates TModel objects from name-value dictionary
        /// and inits TModel properties using reflection.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"/>
        internal IEnumerable<TModel> InstantiateModelsFromNamedValues(
            IEnumerable<IDictionary<string, object>> namedValuesList)
        {
            // Resulting models list.
            var modelsList = new List<TModel>();

            foreach (var namedValues in namedValuesList)
            {
                var model = (TModel)Activator.CreateInstance(typeof(TModel), null);
                var props = model.GetType().GetProperties();

                foreach (var prop in props)
                {
                    if (namedValues.ContainsKey(prop.Name))
                    {
                        var value = namedValues[prop.Name];
                        prop.SetValue(model, value);
                    }
                    else
                        throw new ApplicationException($"Missing value of a TModel property: {prop.Name}.");
                }

                modelsList.Add(model);
            }

            return modelsList;
        }

        //public IEnumerable<TModel> GetAll()
        //{

        //}
    }
}
