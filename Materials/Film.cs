using System;

namespace Materials
{
    /// <summary>
    /// Defines a film material.
    /// </summary>
    public class Film : IMaterial
    {
        /// <summary>
        /// Default ctor (no-color init).
        /// </summary>
        public Film()
        {
            this.Color = Color.Transparent;
            this.Name = "Film";
        }

        /// <summary>
        /// Material name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Color of a film material.
        /// </summary>
        public Color Color { get; }

        /// <summary>
        /// Not-implemented for this material.
        /// </summary>
        /// <param name="color"></param>
        void IMaterial.Paint(Color color) 
        { 
            throw new ApplicationException("Film has a constant color and can't be changed.");
        }

        /// <summary>
        /// Check the equality of this film material instance and other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !(this.GetType().Equals(obj.GetType())))
                return false;

            var film = (Film)obj;

            return this.Color.Equals(film.Color);
        }

        /// <summary>
        /// Returns a hash-code for a film material object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Color.GetHashCode();
        }

        /// <summary>
        /// Returns a formatted string filled with film material props.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format($"{Name}");
        }
    }
}
