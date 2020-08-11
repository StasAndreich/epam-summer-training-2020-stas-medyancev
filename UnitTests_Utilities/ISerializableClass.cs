using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UnitTests_Utilities
{
    [Serializable]
    public class ISerializableClass : ISerializable
    {
        private string name;
        private int intValue;

        public ISerializableClass()
        {
        }

        protected ISerializableClass(SerializationInfo info, 
            StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("Info");

            name = (string)info.GetValue("AltName", typeof(string));
            intValue = (int)info.GetValue("AltIntValue", typeof(int));
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int IntValue
        {
            get => intValue;
            set => intValue = value;
        }

        public virtual void GetObjectData(SerializationInfo info,
            StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("Info");

            info.AddValue("AltName", true);
            info.AddValue("AltIntValue", true);
        }
    }
}
