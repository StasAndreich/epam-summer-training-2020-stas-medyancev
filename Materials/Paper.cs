using System;

namespace Materials
{
    /// <summary>
    /// Defines a paper material.
    /// </summary>
    public class Paper : IMaterial
    {
        /// <summary>
        /// Default ctor (creates a white paper).
        /// </summary>
        public Paper()
        {
            this.color = Color.White;
        }

        /// <summary>
        /// Creates a colored paper.
        /// </summary>
        /// <param name="color"></param>
        public Paper(Color color)
        {
            this.color = color;
        }

        private Color color;
        /// <summary>
        /// Color of a paper material.
        /// </summary>
        public Color Color { get => color; }
        /// <summary>
        /// Indicates whether a paper material
        /// has been repainted once.
        /// </summary>
        public bool IsRepainted { get; private set; }

        /// <summary>
        /// Paints paper in 
        /// </summary>
        /// <param name="color"></param>
        public void Paint(Color color)
        {
            if (!this.IsRepainted)
            {
                this.color = color;
                this.IsRepainted = true;
            }
            else
                throw new ApplicationException("Paper material can be painted" +
                    "only once.");
        }
    }
}
