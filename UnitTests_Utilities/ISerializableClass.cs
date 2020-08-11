using System;
using System.Runtime.Serialization;

namespace UnitTests_Utilities
{
    /// <summary>
    /// Test class that implements ISerializable interface.
    /// </summary>
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

            info.AddValue("AltName", name);
            info.AddValue("AltIntValue", intValue);
        }

        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !(this.GetType().Equals(obj.GetType())))
                return false;

            var @class = (ISerializableClass)obj;

            return this.Name.ToUpper().Equals(@class.Name.ToUpper())
                && this.IntValue.Equals(@class.IntValue);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ IntValue.GetHashCode();
        }
    }
}
