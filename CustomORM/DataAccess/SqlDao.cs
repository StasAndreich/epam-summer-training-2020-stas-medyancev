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
        where TModel : class
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
        /// Selects an entity (first or default if multiple) 
        /// from database by its ID.
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
                // Get id field name.
                var idFieldName = this
                    .GetModelPrimaryKeyNameAndIdValue(null, out int _);

                // Open connection.
                Connection.Open();

                var command = Connection.CreateCommand();
                command.CommandText = $"SELECT * FROM {tableName} " +
                    $"WHERE {idFieldName}=@id;";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter("@id", id));

                // Execute reader.
                var reader = (SqlDataReader) command.ExecuteReader();
                var namedValues = this.GetNamedValuesPairs(reader);
                reader.Close();

                // Get models.
                var models = this.InstantiateModelsFromNamedValues(namedValues);

                // Close connection.
                Connection.Close();

                return models.FirstOrDefault();
            }
            else
                throw new ApplicationException("Current TModel is not a DB table.");
        }

        /// <summary>
        /// Deletes an entity object from a database table.
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(TModel entity)
        {
            var type = typeof(TModel);

            // Check table attrib.
            var tableAttrib = (DbTableAttribute)DbModelMappingCheker
                .CheckDbTableAttrib(type);

            if (tableAttrib != null)
            {
                // Get a table name.
                var tableName = tableAttrib.Name;
                // Get field id and value.
                var idFieldName = this
                    .GetModelPrimaryKeyNameAndIdValue(entity, out int idFieldValue);

                // Open connection.
                Connection.Open();

                var command = Connection.CreateCommand();
                command.CommandText = $"DELETE FROM {tableName} " +
                    $"WHERE {idFieldName}=@id;";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter("@id", idFieldValue));
                // Execute cmd.
                command.ExecuteNonQuery();

                // Close connection.
                Connection.Close();
            }
            else
                throw new ApplicationException("Current TModel is not a DB table.");
        }

        /// <summary>
        /// Selects all entities from database table.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TModel> GetAll()
        {
            var type = typeof(TModel);

            // Check table attrib.
            var tableAttrib = (DbTableAttribute)DbModelMappingCheker
                .CheckDbTableAttrib(type);

            if (tableAttrib != null)
            {
                // Get a table name.
                var tableName = tableAttrib.Name;

                // Open connection.
                Connection.Open();

                var command = Connection.CreateCommand();
                command.CommandText = $"SELECT * FROM {tableName};";
                command.CommandType = CommandType.Text;

                // Execute reader.
                var reader = (SqlDataReader)command.ExecuteReader();
                var namedValues = this.GetNamedValuesPairs(reader);
                reader.Close();

                // Get models.
                var models = this.InstantiateModelsFromNamedValues(namedValues);

                // Close connection.
                Connection.Close();

                return models;
            }
            else
                throw new ApplicationException("Current TModel is not a DB table.");
        }

        /// <summary>
        /// Creates a new entity in its table.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TModel entity)
        {
            var type = typeof(TModel);

            // Check table attrib.
            var tableAttrib = (DbTableAttribute)DbModelMappingCheker
                .CheckDbTableAttrib(type);

            if (tableAttrib != null)
            {
                // Get a table name.
                var tableName = tableAttrib.Name;
                var namedValues = this.GetModelNamedValues(entity);

                // Open connection.
                Connection.Open();

                var command = Connection.CreateCommand();
                // Add fields.
                var cmd = $"INSERT INTO {tableName} (";
                cmd += GetSeparatedStringFromNames(namedValues.Keys.ToList(),
                                                   ",");
                // Add values.
                cmd += ") VALUES (@";
                var valuesStr = GetSeparatedStringFromNames(namedValues.Keys.ToList(),
                                                   ",@");
                cmd += valuesStr + ");";

                command.CommandText = cmd;
                command.CommandType = CommandType.Text;
                // Add params.
                foreach (var val in namedValues)
                {
                    command.Parameters.AddWithValue($"@{val.Key}", val.Value);
                }
                
                if (command.ExecuteNonQuery() == 0)
                    throw new ApplicationException("Row not added.");

                // Close connection.
                Connection.Close();
            }
            else
                throw new ApplicationException("Current TModel is not a DB table.");
        }

        /// <summary>
        /// Updates an entity object in a database table.
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TModel entity)
        {
            throw new NotImplementedException();
        }

        #region Private utils.
        private string GetSeparatedStringFromNames(IEnumerable<string> enumerable,
            string separator)
        {
            var str = "";

            var i = 1;
            foreach (var item in enumerable)
            {
                str += item;
                if (i != enumerable.Count())
                {
                    // Add separator.
                    str += $"{separator}";
                    i++;
                }
            }
            return str;
        } 
        #endregion
    }
}
