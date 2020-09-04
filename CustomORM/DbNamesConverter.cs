using System.Globalization;

namespace CustomORM
{
    /// <summary>
    /// Converts DB names.
    /// </summary>
    public static class DbNamesConverter
    {
        /// <summary>
        /// Returns the plural form of the input parameter.
        /// </summary>
        /// <param name="singularName"></param>
        /// <returns></returns>
        public static string GetPluralName(string singularName)
        {
            var service = System.Data.Entity.Design
                .PluralizationServices.PluralizationService
                .CreateService(CultureInfo.InvariantCulture);
            return service.Pluralize(singularName);
        }
    }
}
