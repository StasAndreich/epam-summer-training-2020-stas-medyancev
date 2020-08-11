using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Utilities
{
    internal sealed class MultiSerializerSerializationBinder
        : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            var assemblyVersion1 = Assembly.GetExecutingAssembly().GetName();
            assemblyVersion1.Version
        }
    }
}
