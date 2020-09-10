using CustomORM.Mapping;
using System;
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
        /// Creates a new entity in its table.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TModel entity)
        {
            var type = typeof(TModel);

            // Check table attrib.
            var tableAttrib = (DbTableAttribute)DbModelMappingCheker
                .CheckDbTableAttrib(type);
        }

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
