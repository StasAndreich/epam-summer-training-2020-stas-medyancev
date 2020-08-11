using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Utilities
{
    /// <summary>
    /// Inherits SerializationBinder.
    /// </summary>
    public sealed class MultiSerializerSerializationBinder
        : SerializationBinder
    {
        /// <summary>
        /// Binds type of serialized data in class loader.
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public override Type BindToType(string assemblyName, string typeName)
        {
            var currentAssembly = Assembly.GetExecutingAssembly().GetName();

            if (currentAssembly.ToString().Equals(assemblyName))
                return Type.GetType($"{typeName}, {assemblyName}");
            else
                throw new SerializationException("Assemblies version mismatch.");
        }
    }
}
