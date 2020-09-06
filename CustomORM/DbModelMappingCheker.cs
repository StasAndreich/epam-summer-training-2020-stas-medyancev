using CustomORM.Mapping;
using System;
using System.Reflection;

namespace CustomORM
{
    /// <summary>
    /// Checks a database models mapping.
    /// </summary>
    public static class DbModelMappingCheker
    {
        /// <summary>
        /// Check whether a model has DbTableAttribute applied.
        /// </summary>
        /// <param name="modelType"></param>
        /// <returns>DbTableAttribute instance or null, if no such
        /// attribute found.
        /// </returns>
        public static Attribute CheckDbTableAttrib(Type modelType)
        {
            return modelType.GetCustomAttribute(typeof(DbTableAttribute));
        }
    }
}
