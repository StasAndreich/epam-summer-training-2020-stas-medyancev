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
        }

        /// <summary>
        /// Color of a film material.
        /// </summary>
        public Color Color { get; }
    }
}
