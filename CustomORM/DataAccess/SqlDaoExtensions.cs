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
    }
}
