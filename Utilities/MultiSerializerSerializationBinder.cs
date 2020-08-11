using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.Linq;

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
            var asmtokens = assemblyName.Split(',');

            // Get asm names.
            var currentName = currentAssembly.Name;
            var name = asmtokens.First();

            // Get asm versions.
            var currentVersion = "Version=" + $"{currentAssembly.Version}";
            var version = "";
            foreach (var token in asmtokens)
            {
                if (token.Contains("Version"))
                {
                    version = token.Trim(' ');
                    break;
                }
            }

            if (!name.Equals(currentName))
                return Type.GetType($"{typeName}, {assemblyName}");

            else if (version.Equals(currentVersion.ToString()))
                return Type.GetType($"{typeName}, {assemblyName}");

            else
                throw new SerializationException("Assemblies version mismatch.");
        }
    }
}
