namespace Materials
{
    /// <summary>
    /// Defines an abstract material class.
    /// </summary>
    public interface IMaterial
    {
        /// <summary>
        /// Material name.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Defines a material color.
        /// </summary>
        Color Color { get; }

        /// <summary>
        /// Paints a material in a specified color.
        /// </summary>
        /// <param name="color"></param>
        void Paint(Color color);
    }
}
