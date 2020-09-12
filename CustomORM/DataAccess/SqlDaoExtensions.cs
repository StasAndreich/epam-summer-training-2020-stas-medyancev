using CustomORM.Mapping;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CustomORM.DataAccess
{
    /// <summary>
    /// Contains SqlDao class extensions.
    /// </summary>
    public static class SqlDaoExtensions
    {
        /// <summary>
        /// Reads data from a database as named values pairs belonging to a table.
        /// </summary>
        /// <param name="_"></param>
        /// <param name="reader"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"/>
        public static IEnumerable<IDictionary<string, object>> GetNamedValuesPairs<TModel>(
            this SqlDao<TModel> _, SqlDataReader reader) 
            where TModel : class
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
        /// <param name="_"></param>
        /// <param name="namedValuesList"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"/>
        public static IEnumerable<TModel> InstantiateModelsFromNamedValues<TModel>(
            this SqlDao<TModel> _, IEnumerable<IDictionary<string, object>> namedValuesList)
            where TModel : class
        {
            // Resulting models list.
            var modelsList = new List<TModel>();

            foreach (var namedValues in namedValuesList)
            {
                var model = (TModel)Activator.CreateInstance(typeof(TModel), null);
                // Get all model props.
                var modelProps = model.GetType().GetProperties();

                foreach (var prop in modelProps)
                {
                    var columnAttribute = (DbColumnAttribute)DbModelMappingCheker
                        .CheckDbColumnAttrib(prop);

                    // Find attrib column names in names values dictionary.
                    if (namedValues.ContainsKey(columnAttribute.Name))
                    {
                        var value = namedValues[columnAttribute.Name];
                        prop.SetValue(model, value);
                    }
                    else
                        throw new ApplicationException($"Missing value of a TModel" +
                            $" property: {prop.Name}. DbColumn: {columnAttribute.Name}.");
                }

                modelsList.Add(model);
            }

            return modelsList;
        }

        /// <summary>
        /// Gets a primary key model member name and value.
        /// </summary>
        /// <param name="_"></param>
        /// <param name="entity"></param>
        /// <param name="idFieldValue">Model ID.</param>
        /// <returns>Model primary key name.</returns>
        public static string GetModelPrimaryKeyNameAndIdValue<TModel>(
            this SqlDao<TModel> _, TModel entity, out int idFieldValue)
            where TModel : class
        {
            var idFieldName = "";
            idFieldValue = 0;

            // Find primary key member.
            var members = typeof(TModel).GetMembers();
            foreach (var member in members)
            {
                var colAttrib = (DbColumnAttribute)DbModelMappingCheker
                    .CheckDbColumnAttrib(member);

                if (colAttrib == null) continue;
                if (colAttrib.IsPrimaryKey == true)
                {
                    idFieldName = colAttrib.Name;
                    if (entity != null)
                        idFieldValue = (int)typeof(TModel).GetProperty(idFieldName)
                            .GetValue(entity);
                    break;
                }
            }

            return idFieldName;
        }
    }
}
