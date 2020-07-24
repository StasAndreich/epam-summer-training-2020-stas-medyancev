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
            this.Name = "Paper";
        }

        /// <summary>
        /// Creates a colored paper.
        /// </summary>
        /// <param name="color"></param>
        public Paper(Color color)
        {
            this.color = color;
            this.Name = "Paper";
        }

        /// <summary>
        /// Material name.
        /// </summary>
        public string Name { get; }

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
        /// Paints paper in a specified color.
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

        /// <summary>
        /// Check the equality of this paper material instance and other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !(this.GetType().Equals(obj.GetType())))
                return false;

            var paper = (Paper)obj;

            return this.Color.Equals(paper.Color);
        }

        /// <summary>
        /// Returns a hash-code for a paper material object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Color.GetHashCode();
        }

        /// <summary>
        /// Returns a formatted string filled with paper material props.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format($"{Name}");
        }
    }
}
